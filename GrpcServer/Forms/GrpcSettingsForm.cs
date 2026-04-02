using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GrpcShared;

namespace GrpcServer.Forms
{
    public partial class GrpcSettingsForm : Form
    {
        public GrpcSettingsForm()
        {
            InitializeComponent();
            LoadCurrentSettings();
        }

        private void LoadCurrentSettings()
        {
            rbWhitelistOn.Checked = WhitelistStore.WhitelistEnabled;
            rbAllowAll.Checked = !WhitelistStore.WhitelistEnabled;
            RefreshClientList();
            UpdateControlStates();
        }

        private void RefreshClientList()
        {
            listBoxClients.Items.Clear();
            foreach (string ip in WhitelistStore.GetAllowedClients())
            {
                listBoxClients.Items.Add(ip);
            }
        }

        private void UpdateControlStates()
        {
            bool whitelistActive = rbWhitelistOn.Checked;
            listBoxClients.Enabled = whitelistActive;
            btnAdd.Enabled = whitelistActive;
            btnRemove.Enabled = whitelistActive && listBoxClients.SelectedIndex >= 0;
        }

        private void rbAllowAll_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControlStates();
        }

        private void rbWhitelistOn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControlStates();
        }

        private void listBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = rbWhitelistOn.Checked && listBoxClients.SelectedIndex >= 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
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

        private void btnRemove_Click(object sender, EventArgs e)
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
                UpdateControlStates();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            WhitelistStore.SetWhitelistEnabled(rbWhitelistOn.Checked);
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
