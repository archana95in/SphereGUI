namespace HapticGUIAuto
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbParticipantId = new System.Windows.Forms.TextBox();
            this.tbSession = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTrialNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbComPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(345, 367);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(176, 49);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Participant ID";
            // 
            // tbParticipantId
            // 
            this.tbParticipantId.Location = new System.Drawing.Point(222, 137);
            this.tbParticipantId.Name = "tbParticipantId";
            this.tbParticipantId.Size = new System.Drawing.Size(299, 38);
            this.tbParticipantId.TabIndex = 2;
            this.tbParticipantId.Text = "P0";
            // 
            // tbSession
            // 
            this.tbSession.Location = new System.Drawing.Point(222, 193);
            this.tbSession.Name = "tbSession";
            this.tbSession.Size = new System.Drawing.Size(299, 38);
            this.tbSession.TabIndex = 3;
            this.tbSession.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Session";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(124, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(315, 69);
            this.label3.TabIndex = 5;
            this.label3.Text = "HapticGUI";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 32);
            this.label4.TabIndex = 7;
            this.label4.Text = "Trial Number";
            // 
            // tbTrialNumber
            // 
            this.tbTrialNumber.Location = new System.Drawing.Point(222, 250);
            this.tbTrialNumber.Name = "tbTrialNumber";
            this.tbTrialNumber.Size = new System.Drawing.Size(299, 38);
            this.tbTrialNumber.TabIndex = 6;
            this.tbTrialNumber.Text = "1";
            this.tbTrialNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbTrialNumber_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 32);
            this.label5.TabIndex = 9;
            this.label5.Text = "COM Port";
            // 
            // tbComPort
            // 
            this.tbComPort.Location = new System.Drawing.Point(222, 306);
            this.tbComPort.Name = "tbComPort";
            this.tbComPort.Size = new System.Drawing.Size(299, 38);
            this.tbComPort.TabIndex = 8;
            this.tbComPort.Text = "COM10";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 448);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbComPort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbTrialNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSession);
            this.Controls.Add(this.tbParticipantId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Main Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbParticipantId;
        private System.Windows.Forms.TextBox tbSession;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTrialNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbComPort;
    }
}