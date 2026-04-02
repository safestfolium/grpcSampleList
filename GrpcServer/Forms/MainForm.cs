using System;
using System.Drawing;
using System.Windows.Forms;
using GrpcShared;

namespace GrpcServer.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            UpdateStatus();
            RefreshHistory();
            WhitelistStore.StateChanged += new Action(OnStateChanged);
        }

        private void OnStateChanged()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateStatus));
                Invoke(new Action(RefreshHistory));
            }
            else
            {
                UpdateStatus();
                RefreshHistory();
            }
        }

        private void UpdateStatus()
        {
            bool enabled = WhitelistStore.WhitelistEnabled;
            if (enabled)
            {
                lblStatus.Text = "Whitelist: ACTIVE";
                lblStatus.ForeColor = Color.Red;
            }
            else
            {
                lblStatus.Text = "Whitelist: OFF (allow all)";
                lblStatus.ForeColor = Color.Green;
            }
        }

        private void RefreshHistory()
        {
            listBoxHistory.Items.Clear();
            foreach (AccessAttempt attempt in WhitelistStore.GetHistory())
            {
                listBoxHistory.Items.Add(attempt.ToString());
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (GrpcSettingsForm form = new GrpcSettingsForm())
            {
                form.ShowDialog(this);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            WhitelistStore.StateChanged -= new Action(OnStateChanged);
            base.OnFormClosed(e);
        }
    }
}
