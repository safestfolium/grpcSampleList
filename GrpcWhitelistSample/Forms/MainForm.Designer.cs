namespace GrpcWhitelistSample.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWhitelistStatus;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.ListBox listBoxHistory;
        private System.Windows.Forms.Button btnSettings;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWhitelistStatus = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.listBoxHistory = new System.Windows.Forms.ListBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 21);
            this.lblTitle.Text = "gRPC Whitelist Server";

            // lblWhitelistStatus
            this.lblWhitelistStatus.AutoSize = true;
            this.lblWhitelistStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblWhitelistStatus.ForeColor = System.Drawing.Color.Red;
            this.lblWhitelistStatus.Location = new System.Drawing.Point(12, 44);
            this.lblWhitelistStatus.Name = "lblWhitelistStatus";
            this.lblWhitelistStatus.Text = "Whitelist: ACTIVE";

            // lblPort
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPort.Location = new System.Drawing.Point(12, 68);
            this.lblPort.Name = "lblPort";
            this.lblPort.Text = "gRPC Port: 50051";

            // lblHistoryTitle
            this.lblHistoryTitle.AutoSize = true;
            this.lblHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHistoryTitle.Location = new System.Drawing.Point(12, 100);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Text = "Access History (newest first):";

            // listBoxHistory
            this.listBoxHistory.Font = new System.Drawing.Font("Courier New", 9F);
            this.listBoxHistory.HorizontalScrollbar = true;
            this.listBoxHistory.Location = new System.Drawing.Point(12, 122);
            this.listBoxHistory.Name = "listBoxHistory";
            this.listBoxHistory.Size = new System.Drawing.Size(660, 330);
            this.listBoxHistory.TabIndex = 0;

            // btnSettings
            this.btnSettings.Location = new System.Drawing.Point(12, 462);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(130, 30);
            this.btnSettings.TabIndex = 1;
            this.btnSettings.Text = "gRPC Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 506);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblWhitelistStatus);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblHistoryTitle);
            this.Controls.Add(this.listBoxHistory);
            this.Controls.Add(this.btnSettings);
            this.MinimumSize = new System.Drawing.Size(706, 545);
            this.Name = "MainForm";
            this.Text = "gRPC Whitelist Server";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
