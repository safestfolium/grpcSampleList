namespace GrpcServer.Forms
{
    partial class AddClientDialog
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblHistoryLabel;
        private System.Windows.Forms.ListBox listBoxHistory;
        private System.Windows.Forms.Label lblManualIp;
        private System.Windows.Forms.TextBox txtManualIp;
        private System.Windows.Forms.Button btnAdd;
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
            this.lblHistoryLabel = new System.Windows.Forms.Label();
            this.listBoxHistory = new System.Windows.Forms.ListBox();
            this.lblManualIp = new System.Windows.Forms.Label();
            this.txtManualIp = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblHistoryLabel
            this.lblHistoryLabel.AutoSize = true;
            this.lblHistoryLabel.Location = new System.Drawing.Point(12, 12);
            this.lblHistoryLabel.Name = "lblHistoryLabel";
            this.lblHistoryLabel.Text = "Clients that attempted access (newest first):";

            // listBoxHistory
            this.listBoxHistory.FormattingEnabled = true;
            this.listBoxHistory.Location = new System.Drawing.Point(12, 32);
            this.listBoxHistory.Name = "listBoxHistory";
            this.listBoxHistory.Size = new System.Drawing.Size(400, 160);
            this.listBoxHistory.TabIndex = 0;
            this.listBoxHistory.SelectedIndexChanged += new System.EventHandler(this.listBoxHistory_SelectedIndexChanged);

            // lblManualIp
            this.lblManualIp.AutoSize = true;
            this.lblManualIp.Location = new System.Drawing.Point(12, 206);
            this.lblManualIp.Name = "lblManualIp";
            this.lblManualIp.Text = "IP Address to add:";

            // txtManualIp
            this.txtManualIp.Location = new System.Drawing.Point(12, 226);
            this.txtManualIp.Name = "txtManualIp";
            this.txtManualIp.Size = new System.Drawing.Size(200, 20);
            this.txtManualIp.TabIndex = 1;

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(12, 260);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 28);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(104, 260);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 28);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // AddClientDialog
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 304);
            this.Controls.Add(this.lblHistoryLabel);
            this.Controls.Add(this.listBoxHistory);
            this.Controls.Add(this.lblManualIp);
            this.Controls.Add(this.txtManualIp);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddClientDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Whitelisted Client";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
