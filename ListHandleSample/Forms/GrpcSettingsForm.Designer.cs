namespace ListHandleSample.Forms
{
    partial class GrpcSettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpAccessMode;
        private System.Windows.Forms.RadioButton rbAllowAny;
        private System.Windows.Forms.RadioButton rbWhitelistOnly;
        private System.Windows.Forms.GroupBox grpClients;
        private System.Windows.Forms.Label lblAllowedIPs;
        private System.Windows.Forms.ListBox listBoxClients;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Button btnRemoveClient;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpAccessMode = new System.Windows.Forms.GroupBox();
            this.rbAllowAny = new System.Windows.Forms.RadioButton();
            this.rbWhitelistOnly = new System.Windows.Forms.RadioButton();
            this.grpClients = new System.Windows.Forms.GroupBox();
            this.lblAllowedIPs = new System.Windows.Forms.Label();
            this.listBoxClients = new System.Windows.Forms.ListBox();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.btnRemoveClient = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpAccessMode.SuspendLayout();
            this.grpClients.SuspendLayout();
            this.SuspendLayout();

            // grpAccessMode
            this.grpAccessMode.Controls.Add(this.rbWhitelistOnly);
            this.grpAccessMode.Controls.Add(this.rbAllowAny);
            this.grpAccessMode.Location = new System.Drawing.Point(12, 12);
            this.grpAccessMode.Name = "grpAccessMode";
            this.grpAccessMode.Size = new System.Drawing.Size(400, 80);
            this.grpAccessMode.TabIndex = 0;
            this.grpAccessMode.TabStop = false;
            this.grpAccessMode.Text = "Access Mode";

            // rbAllowAny
            this.rbAllowAny.AutoSize = true;
            this.rbAllowAny.Location = new System.Drawing.Point(12, 20);
            this.rbAllowAny.Name = "rbAllowAny";
            this.rbAllowAny.Size = new System.Drawing.Size(180, 17);
            this.rbAllowAny.TabIndex = 0;
            this.rbAllowAny.Text = "Allow any client to access";
            this.rbAllowAny.UseVisualStyleBackColor = true;
            this.rbAllowAny.CheckedChanged += new System.EventHandler(this.rbAllowAny_CheckedChanged);

            // rbWhitelistOnly
            this.rbWhitelistOnly.AutoSize = true;
            this.rbWhitelistOnly.Checked = true;
            this.rbWhitelistOnly.Location = new System.Drawing.Point(12, 44);
            this.rbWhitelistOnly.Name = "rbWhitelistOnly";
            this.rbWhitelistOnly.Size = new System.Drawing.Size(240, 17);
            this.rbWhitelistOnly.TabIndex = 1;
            this.rbWhitelistOnly.TabStop = true;
            this.rbWhitelistOnly.Text = "Allow only whitelisted clients to access";
            this.rbWhitelistOnly.UseVisualStyleBackColor = true;
            this.rbWhitelistOnly.CheckedChanged += new System.EventHandler(this.rbWhitelistOnly_CheckedChanged);

            // grpClients
            this.grpClients.Controls.Add(this.lblAllowedIPs);
            this.grpClients.Controls.Add(this.listBoxClients);
            this.grpClients.Controls.Add(this.btnAddClient);
            this.grpClients.Controls.Add(this.btnRemoveClient);
            this.grpClients.Location = new System.Drawing.Point(12, 104);
            this.grpClients.Name = "grpClients";
            this.grpClients.Size = new System.Drawing.Size(400, 260);
            this.grpClients.TabIndex = 1;
            this.grpClients.TabStop = false;
            this.grpClients.Text = "Whitelisted Clients";

            // lblAllowedIPs
            this.lblAllowedIPs.AutoSize = true;
            this.lblAllowedIPs.Location = new System.Drawing.Point(8, 20);
            this.lblAllowedIPs.Name = "lblAllowedIPs";
            this.lblAllowedIPs.Text = "Allowed IP Addresses:";

            // listBoxClients
            this.listBoxClients.Location = new System.Drawing.Point(8, 38);
            this.listBoxClients.Name = "listBoxClients";
            this.listBoxClients.Size = new System.Drawing.Size(384, 173);
            this.listBoxClients.TabIndex = 0;

            // btnAddClient
            this.btnAddClient.Location = new System.Drawing.Point(8, 220);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(100, 28);
            this.btnAddClient.TabIndex = 1;
            this.btnAddClient.Text = "+ Add Client";
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);

            // btnRemoveClient
            this.btnRemoveClient.Location = new System.Drawing.Point(116, 220);
            this.btnRemoveClient.Name = "btnRemoveClient";
            this.btnRemoveClient.Size = new System.Drawing.Size(130, 28);
            this.btnRemoveClient.TabIndex = 2;
            this.btnRemoveClient.Text = "- Remove Selected";
            this.btnRemoveClient.UseVisualStyleBackColor = true;
            this.btnRemoveClient.Click += new System.EventHandler(this.btnRemoveClient_Click);

            // btnOK
            this.btnOK.Location = new System.Drawing.Point(256, 380);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 28);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(337, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // GrpcSettingsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 420);
            this.Controls.Add(this.grpAccessMode);
            this.Controls.Add(this.grpClients);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GrpcSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "gRPC Settings";
            this.grpAccessMode.ResumeLayout(false);
            this.grpAccessMode.PerformLayout();
            this.grpClients.ResumeLayout(false);
            this.grpClients.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
