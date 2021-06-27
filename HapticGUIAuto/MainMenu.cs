using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace HapticGUIAuto
{
    public partial class MainMenu : Form
    {
        SoundPlayer posSound, negSound;
        public MainMenu()
        {
            InitializeComponent();
            posSound = new SoundPlayer(Properties.Resources.sine_pos_asym_aud_75hz_40s);
            negSound = new SoundPlayer(Properties.Resources.sine_neg_asym_aud_75hz_40s);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string participantId = tbParticipantId.Text;
            string session = tbSession.Text;
            string comPort = tbComPort.Text;

            int trialNumber;
            try
            {
                trialNumber = Convert.ToInt32(tbTrialNumber.Text);
                trialNumber -= 1;
            }
            catch(Exception) {
                trialNumber = 0;
            }

            if (trialNumber < 0 || trialNumber > 79)
            {
                MessageBox.Show("ERROR: Trial Number Out Of Range");
            }
            else if (participantId.Length <= 0)
            {
                MessageBox.Show("ERROR: Participant ID Cannot Be Empty");
            }
            else if (session.Length <= 0)
            {
                MessageBox.Show("ERROR: Session Cannot Be Empty");
            }
            else if (!checkComPort(comPort))
            {
                MessageBox.Show("ERROR: Invalid COM Port");
            }
            else
            {
                TaskWindow taskWindow = new TaskWindow(participantId, session, trialNumber, comPort);
                this.Hide();
                taskWindow.ShowDialog();
                this.Close();
            }
        }

        private bool checkComPort(string comPort)
        {
            bool isValid = false;
            try
            {
                SerialPort serialPort = new SerialPort();
                serialPort.BaudRate = 9600;
                serialPort.PortName = comPort;
                serialPort.Open();
                serialPort.Write("0");
                serialPort.Close();

                isValid = true;
            }
            catch (Exception)
            {
                isValid = false;
            }

            return isValid;
        }

        private void tbTrialNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        public void playSound(bool isPositive)
        {
            posSound.Stop();
            negSound.Stop();
            if (isPositive)
            {
                posSound.Play();
            }
            else
            {
                negSound.Play();
            }
        }
    }
}
