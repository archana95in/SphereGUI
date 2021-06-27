using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HapticGUIAuto
{
    public partial class DirectionSelectionWindow : Form
    {
        private const string filename = "data.csv";
        private const string header = "Participant ID,Session,Trial Number,Timestamp,Ground Truth,Selected Direction\n";

        string[] sliceDefaultColors = { "#AAAAAA", "#888888", "#AAAAAA", "#888888", "#AAAAAA", "#888888", "#AAAAAA", "#888888" };
        string hoverColor = "#7FDBFF";
        string clickColor = "#0074D9";

        bool isClicked = false;

        string participantId, session, comPort;
        int trialNumber, groundTruth;

        public DirectionSelectionWindow(string participantId, string session, int trialNumber, int groundTruth, string comPort)
        {
            InitializeComponent();

            this.participantId = participantId;
            this.session = session;
            this.trialNumber = trialNumber;
            this.groundTruth = groundTruth;
            this.comPort = comPort;
        }

        // --------------------------------------------------------------------
        // SYSTEM LOGIC
        // --------------------------------------------------------------------
        private void chDirection_MouseClick(object sender, MouseEventArgs e)
        {
            double result = -1;
            HitTestResult hit = chDirection.HitTest(e.X, e.Y, ChartElementType.DataPoint);

            if (hit.PointIndex >= 0 && hit.Series != null)
            {
                DataPoint dataPoint = chDirection.Series[0].Points[hit.PointIndex];
                result = dataPoint.XValue;
            }

            if (result != -1)
            {
                if (!File.Exists(filename))
                {
                    File.WriteAllText(filename, header);
                }
                var record = participantId + "," + session + "," + trialNumber + "," + getTime() + "," + groundTruth + "," + result + "\n";
                File.AppendAllText(filename, record);

                trialNumber += 1;
                if (trialNumber % 16 != 0)
                {
                    TaskWindow taskWindow = new TaskWindow(participantId, session, trialNumber, comPort);
                    this.Hide();
                    taskWindow.ShowDialog();
                    this.Close();
                }
                else
                {
                    PauseWindow pauseWindow = new PauseWindow(participantId, session, trialNumber, comPort);
                    this.Hide();
                    pauseWindow.ShowDialog();
                    this.Close();
                }
            }
        }

        private string getTime()
        {
            return DateTime.Now.ToString(new CultureInfo("en-US"));
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            TaskWindow taskWindow = new TaskWindow(participantId, session, trialNumber, comPort);
            this.Hide();
            taskWindow.ShowDialog();
            this.Close();
        }

        // --------------------------------------------------------------------
        // VISUAL COMPONENTS
        // --------------------------------------------------------------------
        private void chDirection_MouseMove(object sender, MouseEventArgs e)
        {
            int hitIdx = -1;
            HitTestResult hit = chDirection.HitTest(e.X, e.Y, ChartElementType.DataPoint);

            if (hit.PointIndex >= 0 && hit.Series != null)
            {
                hitIdx = hit.PointIndex;
            }

            string assignColor = "";
            if (!isClicked)
            {
                for (int i = 0; i < 8; i++)
                {
                    assignColor = sliceDefaultColors[i];
                    if (i == hitIdx)
                    {
                        assignColor = hoverColor;
                    }

                    chDirection.Series[0].Points[i].Color = System.Drawing.ColorTranslator.FromHtml(assignColor);
                }
            }
            
        }

        private void chDirection_MouseDown(object sender, MouseEventArgs e)
        {
            HitTestResult hit = chDirection.HitTest(e.X, e.Y, ChartElementType.DataPoint);

            if (hit.PointIndex >= 0 && hit.Series != null)
            {
                isClicked = true;
                string assignColor = "";
                for (int i = 0; i < 8; i++)
                {
                    assignColor = sliceDefaultColors[i];
                    if (i == hit.PointIndex)
                    {
                        assignColor = clickColor;
                    }

                    chDirection.Series[0].Points[i].Color = System.Drawing.ColorTranslator.FromHtml(assignColor);
                }
            }
        }

        private void chDirection_MouseUp(object sender, MouseEventArgs e)
        {
            isClicked = false;
        }
    }
}
