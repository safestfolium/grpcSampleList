namespace GrpcServer.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ListBox listBoxHistory;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.Button btnSettings;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.listBoxHistory = new System.Windows.Forms.ListBox();
            this.lblHistory = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 24);
            this.lblTitle.Text = "gRPC Whitelist Server";

            // lblPort
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(14, 44);
            this.lblPort.Name = "lblPort";
            this.lblPort.Text = string.Format("Listening on port: {0}", GrpcServerHost.Port);

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(14, 66);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Whitelist: ACTIVE";
            this.lblStatus.ForeColor = System.Drawing.Color.Red;

            // btnSettings
            this.btnSettings.Location = new System.Drawing.Point(14, 94);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(130, 28);
            this.btnSettings.Text = "gRPC Settings";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);

            // lblHistory
            this.lblHistory.AutoSize = true;
            this.lblHistory.Location = new System.Drawing.Point(14, 134);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Text = "Access History (newest first):";

            // listBoxHistory
            this.listBoxHistory.Font = new System.Drawing.Font("Courier New", 9F);
            this.listBoxHistory.FormattingEnabled = true;
            this.listBoxHistory.Location = new System.Drawing.Point(14, 154);
            this.listBoxHistory.Name = "listBoxHistory";
            this.listBoxHistory.Size = new System.Drawing.Size(650, 300);
            this.listBoxHistory.TabIndex = 0;

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 470);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.listBoxHistory);
            this.Name = "MainForm";
            this.Text = "gRPC Whitelist Server";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
