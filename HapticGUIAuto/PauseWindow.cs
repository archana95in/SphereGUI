using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HapticGUIAuto
{
    public partial class PauseWindow : Form
    {
        private int countdown = 0;

        string participantId, session, comPort;
        int trialNumber;

        public PauseWindow(string participantId, string session, int trialNumber, string comPort)
        {
            InitializeComponent();

            this.participantId = participantId;
            this.session = session;
            this.trialNumber = trialNumber;
            this.comPort = comPort;

            restTimer.Stop();

            if (this.trialNumber != 80)
            {
                countdown = 120;
                lblRestTimer.Text = countdown.ToString();
                lblRestInstructions.Text = "The experiment will resume after a 2 minute break automatically.";
                restTimer.Start();
            }
            else
            {
                lblRestInstructions.Text = "This is the end of the experiment. Thank you for participating!";
                lblRestTimer.Text = "";
            }
        }

        private void PauseWindow_Load(object sender, EventArgs e)
        {

        }

        private void restTimer_Tick(object sender, EventArgs e)
        {
            if (countdown > 0)
            {
                countdown--;
                lblRestTimer.Text = countdown.ToString();
            }
            else
            {
                restTimer.Stop();
                continueExperiment();
            }
        }

        private void continueExperiment()
        {
            TaskWindow taskWindow = new TaskWindow(participantId, session, trialNumber, comPort);
            this.Hide();
            taskWindow.ShowDialog();
            this.Close();
        }
    }
}
