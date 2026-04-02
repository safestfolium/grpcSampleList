namespace GrpcWhitelistSample.Forms
{
    partial class AddClientDialog
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblHistoryLabel;
        private System.Windows.Forms.ListBox listBoxHistory;
        private System.Windows.Forms.Label lblManualEntry;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHistoryLabel = new System.Windows.Forms.Label();
            this.listBoxHistory = new System.Windows.Forms.ListBox();
            this.lblManualEntry = new System.Windows.Forms.Label();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblHistoryLabel
            this.lblHistoryLabel.AutoSize = true;
            this.lblHistoryLabel.Location = new System.Drawing.Point(12, 12);
            this.lblHistoryLabel.Name = "lblHistoryLabel";
            this.lblHistoryLabel.Text = "Select from access history (newest IP first):";

            // listBoxHistory
            this.listBoxHistory.Location = new System.Drawing.Point(12, 30);
            this.listBoxHistory.Name = "listBoxHistory";
            this.listBoxHistory.Size = new System.Drawing.Size(360, 147);
            this.listBoxHistory.TabIndex = 0;
            this.listBoxHistory.SelectedIndexChanged += new System.EventHandler(this.listBoxHistory_SelectedIndexChanged);

            // lblManualEntry
            this.lblManualEntry.AutoSize = true;
            this.lblManualEntry.Location = new System.Drawing.Point(12, 192);
            this.lblManualEntry.Name = "lblManualEntry";
            this.lblManualEntry.Text = "Or enter IP address manually:";

            // txtIpAddress
            this.txtIpAddress.Location = new System.Drawing.Point(12, 210);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(360, 20);
            this.txtIpAddress.TabIndex = 1;

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(216, 246);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 28);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(297, 246);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // AddClientDialog
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 286);
            this.Controls.Add(this.lblHistoryLabel);
            this.Controls.Add(this.listBoxHistory);
            this.Controls.Add(this.lblManualEntry);
            this.Controls.Add(this.txtIpAddress);
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
