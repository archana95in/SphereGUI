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

        private int[] trialAngles = { 
            135, 45, 90, 0, 180, 270, 225, 315, 
            180, 90, 270, 135, 0, 315, 225, 45, 
            315, 225, 0, 270, 135, 180, 45, 90, 
            315, 180, 0, 45, 225, 135, 270, 90, 
            270, 135, 180, 45, 225, 0, 315, 90, 
            270, 90, 135, 180, 225, 315, 0, 45, 
            225, 90, 0, 135, 45, 180, 270, 315, 
            180, 45, 270, 135, 315, 0, 90, 225, 
            135, 315, 0, 90, 180, 45, 270, 225, 
            0, 225, 45, 180, 90, 315, 135, 270
        };

        private string[] stateNames = { "Idle", "Playing", "Paused", "Playing", "Waiting" };
        private int[] stateCountdowns = { 5, 5, 2, 5, 100 };
        // private int[] stateCountdowns = { 0, 0, 0, 0, 100 };
        private int stateIdx = 0;

        const string introMsg = "A sample vibration will now be played twice with a 2 second interval after which you will be asked to identify the direction of the push or pull.";

        int countdown = 0;

        string participantId, session, comPort;
        int trialNumber;

        SoundPlayer posSound, negSound;

        SerialPort serialPort;

        public TaskWindow(string participantId, string session, int trialNumber, string comPort)
        {
            InitializeComponent();

            this.participantId = participantId;
            this.session = session;
            this.trialNumber = trialNumber;
            this.comPort = comPort;

            serialPort = new SerialPort();
            serialPort.BaudRate = 9600;
            serialPort.PortName = comPort;

            timer.Stop();

            posSound = new SoundPlayer(Properties.Resources.sine_pos_asym_aud_75hz_40s);
            negSound = new SoundPlayer(Properties.Resources.sine_neg_asym_aud_75hz_40s);

            lblParticipantId.Text = participantId;
            lblSession.Text = session;
            lblTrialNumber.Text = (trialNumber + 1).ToString();

            lblInstructions.Text = introMsg;

            pipeline();
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

        private void playSound(int angle)
        {
            bool isPositive = false;
            if (angle < 180)
            {
                isPositive = true;
            }
            playSound(isPositive);
        }

        private void stopSound()
        {
            posSound.Stop();
            negSound.Stop();
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
            if (stateIdx != 4)
            {
                countdown = stateCountdowns[stateIdx];
                lblTimer.Text = countdown.ToString();
                lblStatus.Text = stateNames[stateIdx];

                if (stateNames[stateIdx] == "Idle")
                {
                    rotateDevice(trialAngles[trialNumber]);
                }

                if (stateNames[stateIdx] == "Playing")
                {
                    playSound(trialAngles[trialNumber]);
                }

                timer.Start();
            }
            else
            {
                DirectionSelectionWindow directionSelectionWindow = new DirectionSelectionWindow(participantId, session, trialNumber, trialAngles[trialNumber], comPort);
                this.Hide();
                directionSelectionWindow.ShowDialog();
                this.Close();
            }
        }

        private void rotateDevice(int angle)
        {
            serialPort.Open();
            serialPort.Write(angle.ToString());
            serialPort.Close();
        }

    }
}
