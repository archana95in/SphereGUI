using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO.Ports;

namespace HapticGUIAuto
{
    public partial class TaskWindow : Form
    {
        bool reverseSignals = false;

        private string[] trialDirections =
        {
            "U", "F", "L", "R", "D", "B",
            "U", "D", "L", "R", "F", "B", 
            "L", "B", "F", "D", "R", "U", 
            "D", "R", "L", "F", "U", "B", 
            "F", "L", "D", "U", "R", "B", 
            "R", "L", "F", "B", "U", "D", 
            "F", "U", "D", "R", "L", "B", 
            "U", "R", "D", "L", "F", "B", 
            "R", "L", "B", "D", "U", "F", 
            "U", "D", "F", "B", "L", "R"
        };

        private string[] stateNames = { "Playing", "Paused", "Playing", "Waiting" };
        private int[] stateCountdowns = { 5, 2, 5, 100 };
        // private int[] stateCountdowns = { 0, 0, 0, 100 };
        private int stateIdx = 0;

        const string introMsg = "A sample haptic feedback will be played twice with a 2 second interval after which you will be asked to identify the direction of the push or pull.";

        int countdown = 0;

        string participantId, session;
        int trialNumber;

        SoundPlayer posSound, negSound;

        public TaskWindow(string participantId, string session, int trialNumber)
        {
            InitializeComponent();

            this.participantId = participantId;
            this.session = session;
            this.trialNumber = trialNumber;

            timer.Stop();

            posSound = new SoundPlayer(Properties.Resources.sine_pos_asym_aud_75hz_40s);
            negSound = new SoundPlayer(Properties.Resources.sine_neg_asym_aud_75hz_40s);

            lblParticipantId.Text = participantId;
            lblSession.Text = session;
            lblTrialNumber.Text = (trialNumber + 1).ToString();

            lblInstructions.Text = introMsg;

            lblStatus.Text = "Waiting";
            lblTimer.Text = "-";
        }

        // Pass argument "true" to play positive signal, "false" to play negative signal
        // e.g., playSound(true)  => Plays positive signal
        //       playSound(false) => Plays negative signal
        private void playSound(bool isPositive)
        {
            stopSound();

            if (reverseSignals)
            {
                isPositive = !isPositive;
            }

            if (isPositive)
            {
                posSound.Play();
            }
            else
            {
                negSound.Play();
            }
        }

        /*
         * Direction Mapping
         * 'F': Forward     => Negative
         * 'B': Backward    => Positive
         * 'L': Left        => Positive
         * 'R': Right       => Negative
         * 'U': Up          => Negative
         * 'D': Down        => Positive
         */
        private void playSound(string direction)
        {
            bool isPositive = false;
            if (direction == "B" || direction == "L" || direction == "D")
            {
                isPositive = true;
            }
            else
            {
                isPositive = false;
            }

            if (reverseSignals)
            {
                isPositive = !isPositive;
            }

            playSound(isPositive);
        }

        private void stopSound()
        {
            posSound.Stop();
            negSound.Stop();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            startBtn.Enabled = false;
            pipeline();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            if (trialNumber == 0)
            {
                backBtn.Enabled = false;
            }
            else
            {
                var newTrialNumber = trialNumber - 1;
                DirectionSelectionWindow directionSelectionWindow = new DirectionSelectionWindow(participantId, session, newTrialNumber, trialDirections[newTrialNumber]);
                this.Hide();
                directionSelectionWindow.ShowDialog();
                this.Close();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (countdown > 0)
            {
                countdown--;
                lblTimer.Text = countdown.ToString();
            }
            else
            {
                timer.Stop();
                stateIdx++;
                pipeline();
            }
        }

        private void pipeline()
        {
            stopSound();
            if (stateIdx != 3)
            {
                countdown = stateCountdowns[stateIdx];
                lblTimer.Text = countdown.ToString();
                lblStatus.Text = stateNames[stateIdx];

                if (stateNames[stateIdx] == "Playing")
                {
                    playSound(trialDirections[trialNumber]);
                }

                timer.Start();
            }
            else
            {
                DirectionSelectionWindow directionSelectionWindow = new DirectionSelectionWindow(participantId, session, trialNumber, trialDirections[trialNumber]);
                this.Hide();
                directionSelectionWindow.ShowDialog();
                this.Close();
            }
        }

    }
}
