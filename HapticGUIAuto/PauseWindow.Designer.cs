namespace HapticGUIAuto
{
    partial class PauseWindow
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
            this.components = new System.ComponentModel.Container();
            this.lblRestTimer = new System.Windows.Forms.Label();
            this.lblRestInstructions = new System.Windows.Forms.Label();
            this.restTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblRestTimer
            // 
            this.lblRestTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestTimer.Location = new System.Drawing.Point(219, 50);
            this.lblRestTimer.Name = "lblRestTimer";
            this.lblRestTimer.Size = new System.Drawing.Size(344, 96);
            this.lblRestTimer.TabIndex = 1;
            this.lblRestTimer.Text = "120";
            this.lblRestTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRestInstructions
            // 
            this.lblRestInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestInstructions.Location = new System.Drawing.Point(26, 158);
            this.lblRestInstructions.Name = "lblRestInstructions";
            this.lblRestInstructions.Size = new System.Drawing.Size(748, 262);
            this.lblRestInstructions.TabIndex = 2;
            this.lblRestInstructions.Text = "label";
            this.lblRestInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // restTimer
            // 
            this.restTimer.Interval = 1000;
            this.restTimer.Tick += new System.EventHandler(this.restTimer_Tick);
            // 
            // PauseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblRestInstructions);
            this.Controls.Add(this.lblRestTimer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PauseWindow";
            this.Text = "Pause Window";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRestTimer;
        private System.Windows.Forms.Label lblRestInstructions;
        private System.Windows.Forms.Timer restTimer;
    }
}