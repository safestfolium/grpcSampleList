using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GrpcWhitelistSample.Core;

namespace GrpcWhitelistSample.Forms
{
    public partial class GrpcSettingsForm : Form
    {
        public GrpcSettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            bool whitelistEnabled = WhitelistStore.IsWhitelistEnabled();
            rbAllowAny.Checked = !whitelistEnabled;
            rbWhitelistOnly.Checked = whitelistEnabled;
            RefreshClientList();
            UpdateControlStates();
        }

        private void RefreshClientList()
        {
            listBoxClients.Items.Clear();
            List<string> clients = WhitelistStore.GetAllowedClients();
            foreach (string client in clients)
            {
                listBoxClients.Items.Add(client);
            }
        }

        private void UpdateControlStates()
        {
            bool whitelistActive = rbWhitelistOnly.Checked;
            listBoxClients.Enabled = whitelistActive;
            btnAddClient.Enabled = whitelistActive;
            btnRemoveClient.Enabled = whitelistActive;
        }

        private void rbAllowAny_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControlStates();
        }

        private void rbWhitelistOnly_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControlStates();
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            using (AddClientDialog dlg = new AddClientDialog())
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    string ip = dlg.SelectedIp;
                    if (!string.IsNullOrEmpty(ip))
                    {
                        WhitelistStore.AddAllowedClient(ip);
                        RefreshClientList();
                    }
                }
            }
        }

        private void btnRemoveClient_Click(object sender, EventArgs e)
        {
            if (listBoxClients.SelectedItem == null) return;
            string ip = listBoxClients.SelectedItem.ToString();
            DialogResult result = MessageBox.Show(
                string.Format("Remove '{0}' from the whitelist?", ip),
                "Confirm Remove",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                WhitelistStore.RemoveAllowedClient(ip);
                RefreshClientList();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            WhitelistStore.SetWhitelistEnabled(rbWhitelistOnly.Checked);
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
