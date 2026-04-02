namespace GrpcServer.Forms
{
    partial class GrpcSettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox grpAccessMode;
        private System.Windows.Forms.RadioButton rbAllowAll;
        private System.Windows.Forms.RadioButton rbWhitelistOn;
        private System.Windows.Forms.GroupBox grpWhitelistedClients;
        private System.Windows.Forms.Label lblAllowedIPs;
        private System.Windows.Forms.ListBox listBoxClients;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;

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
            this.grpAccessMode = new System.Windows.Forms.GroupBox();
            this.rbAllowAll = new System.Windows.Forms.RadioButton();
            this.rbWhitelistOn = new System.Windows.Forms.RadioButton();
            this.grpWhitelistedClients = new System.Windows.Forms.GroupBox();
            this.lblAllowedIPs = new System.Windows.Forms.Label();
            this.listBoxClients = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpAccessMode.SuspendLayout();
            this.grpWhitelistedClients.SuspendLayout();
            this.SuspendLayout();

            // grpAccessMode
            this.grpAccessMode.Controls.Add(this.rbWhitelistOn);
            this.grpAccessMode.Controls.Add(this.rbAllowAll);
            this.grpAccessMode.Location = new System.Drawing.Point(12, 12);
            this.grpAccessMode.Name = "grpAccessMode";
            this.grpAccessMode.Size = new System.Drawing.Size(440, 80);
            this.grpAccessMode.Text = "Access Mode";

            // rbAllowAll
            this.rbAllowAll.AutoSize = true;
            this.rbAllowAll.Location = new System.Drawing.Point(10, 22);
            this.rbAllowAll.Name = "rbAllowAll";
            this.rbAllowAll.Text = "Allow any client to access";
            this.rbAllowAll.CheckedChanged += new System.EventHandler(this.rbAllowAll_CheckedChanged);

            // rbWhitelistOn
            this.rbWhitelistOn.AutoSize = true;
            this.rbWhitelistOn.Checked = true;
            this.rbWhitelistOn.Location = new System.Drawing.Point(10, 48);
            this.rbWhitelistOn.Name = "rbWhitelistOn";
            this.rbWhitelistOn.Text = "Allow only whitelisted clients to access";
            this.rbWhitelistOn.CheckedChanged += new System.EventHandler(this.rbWhitelistOn_CheckedChanged);

            // grpWhitelistedClients
            this.grpWhitelistedClients.Controls.Add(this.lblAllowedIPs);
            this.grpWhitelistedClients.Controls.Add(this.listBoxClients);
            this.grpWhitelistedClients.Controls.Add(this.btnAdd);
            this.grpWhitelistedClients.Controls.Add(this.btnRemove);
            this.grpWhitelistedClients.Location = new System.Drawing.Point(12, 102);
            this.grpWhitelistedClients.Name = "grpWhitelistedClients";
            this.grpWhitelistedClients.Size = new System.Drawing.Size(440, 240);
            this.grpWhitelistedClients.Text = "Whitelisted Clients";

            // lblAllowedIPs
            this.lblAllowedIPs.AutoSize = true;
            this.lblAllowedIPs.Location = new System.Drawing.Point(10, 22);
            this.lblAllowedIPs.Name = "lblAllowedIPs";
            this.lblAllowedIPs.Text = "Allowed IP Addresses:";

            // listBoxClients
            this.listBoxClients.FormattingEnabled = true;
            this.listBoxClients.Location = new System.Drawing.Point(10, 42);
            this.listBoxClients.Name = "listBoxClients";
            this.listBoxClients.Size = new System.Drawing.Size(300, 186);
            this.listBoxClients.TabIndex = 0;
            this.listBoxClients.SelectedIndexChanged += new System.EventHandler(this.listBoxClients_SelectedIndexChanged);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(322, 42);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(106, 28);
            this.btnAdd.Text = "  + Add Client";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnRemove
            this.btnRemove.Location = new System.Drawing.Point(322, 80);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(106, 28);
            this.btnRemove.Text = "  - Remove Selected";
            this.btnRemove.Enabled = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            // btnOK
            this.btnOK.Location = new System.Drawing.Point(280, 360);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 28);
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(372, 360);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 28);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // GrpcSettingsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 400);
            this.Controls.Add(this.grpAccessMode);
            this.Controls.Add(this.grpWhitelistedClients);
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
            this.grpWhitelistedClients.ResumeLayout(false);
            this.grpWhitelistedClients.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
