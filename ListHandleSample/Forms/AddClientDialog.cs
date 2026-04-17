using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ListHandleSample.Core;

namespace ListHandleSample.Forms
{
    public partial class AddClientDialog : Form
    {
        public string SelectedIp { get; private set; }

        public AddClientDialog()
        {
            InitializeComponent();
            LoadHistory();
        }

        private void LoadHistory()
        {
            listBoxHistory.Items.Clear();
            List<AccessAttempt> history = WhitelistStore.GetHistory();
            List<string> allowedClients = WhitelistStore.GetAllowedClients();

            // Get distinct IPs, preserving newest-first order
            List<string> seenIps = new List<string>();
            foreach (AccessAttempt attempt in history)
            {
                if (!seenIps.Contains(attempt.Ip))
                {
                    seenIps.Add(attempt.Ip);
                    bool alreadyWhitelisted = allowedClients.Contains(attempt.Ip);
                    string display = alreadyWhitelisted
                        ? string.Format("{0}  (already whitelisted)", attempt.Ip)
                        : attempt.Ip;
                    listBoxHistory.Items.Add(display);
                }
            }

            if (listBoxHistory.Items.Count == 0)
            {
                listBoxHistory.Items.Add("(no access history yet)");
            }
        }

        private void listBoxHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxHistory.SelectedItem == null) return;
            string selected = listBoxHistory.SelectedItem.ToString();
            if (selected == "(no access history yet)") return;

            // Strip any suffix like "  (already whitelisted)"
            int suffixIndex = selected.IndexOf("  (");
            string ip = suffixIndex >= 0 ? selected.Substring(0, suffixIndex) : selected;
            txtIpAddress.Text = ip.Trim();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string ip = txtIpAddress.Text.Trim();
            if (string.IsNullOrEmpty(ip))
            {
                MessageBox.Show("Please enter an IP address.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SelectedIp = ip;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
