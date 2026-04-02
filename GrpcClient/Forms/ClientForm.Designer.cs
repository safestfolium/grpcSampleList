namespace GrpcClient.Forms
{
    partial class ClientForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblResponse;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;

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
            this.lblHost = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblResponse = new System.Windows.Forms.Label();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // lblHost
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(12, 14);
            this.lblHost.Name = "lblHost";
            this.lblHost.Text = "Server Host:";

            // txtHost
            this.txtHost.Location = new System.Drawing.Point(110, 11);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(150, 20);
            this.txtHost.Text = "localhost";
            this.txtHost.TabIndex = 0;

            // lblPort
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(12, 42);
            this.lblPort.Name = "lblPort";
            this.lblPort.Text = "Port:";

            // txtPort
            this.txtPort.Location = new System.Drawing.Point(110, 39);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(80, 20);
            this.txtPort.Text = "50051";
            this.txtPort.TabIndex = 1;

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 70);
            this.lblName.Name = "lblName";
            this.lblName.Text = "Your Name:";

            // txtName
            this.txtName.Location = new System.Drawing.Point(110, 67);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 2;

            // btnSend
            this.btnSend.Location = new System.Drawing.Point(12, 96);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(130, 28);
            this.btnSend.Text = "Send SayHello";
            this.btnSend.TabIndex = 3;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);

            // lblResponse
            this.lblResponse.AutoSize = true;
            this.lblResponse.Location = new System.Drawing.Point(12, 136);
            this.lblResponse.Name = "lblResponse";
            this.lblResponse.Text = "Response:";

            // txtResponse
            this.txtResponse.Location = new System.Drawing.Point(12, 154);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ReadOnly = true;
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponse.Size = new System.Drawing.Size(560, 60);
            this.txtResponse.TabIndex = 4;

            // lblLog
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(12, 226);
            this.lblLog.Name = "lblLog";
            this.lblLog.Text = "Call Log:";

            // listBoxLog
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(12, 244);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(560, 200);
            this.listBoxLog.TabIndex = 5;

            // statusStrip
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.statusLabel });
            this.statusStrip.Location = new System.Drawing.Point(0, 460);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(590, 22);

            // statusLabel
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Text = "Ready";

            // ClientForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 482);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblResponse);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.statusStrip);
            this.Name = "ClientForm";
            this.Text = "gRPC Client";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
