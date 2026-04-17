using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GrpcWhitelistSample.Core;

namespace GrpcWhitelistSample.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            WhitelistStore.StateChanged += OnStateChanged;
            RefreshUI();
        }

        private void OnStateChanged()
        {
            if (InvokeRequired)
                Invoke(new Action(RefreshUI));
            else
                RefreshUI();
        }

        private void RefreshUI()
        {
            bool enabled = WhitelistStore.IsWhitelistEnabled();
            lblWhitelistStatus.Text = enabled ? "Whitelist: ACTIVE" : "Whitelist: OFF";
            lblWhitelistStatus.ForeColor = enabled ? Color.Red : Color.Green;

            listBoxHistory.Items.Clear();
            List<AccessAttempt> history = WhitelistStore.GetHistory();
            foreach (AccessAttempt attempt in history)
            {
                listBoxHistory.Items.Add(string.Format("{0}  {1}  {2}",
                    attempt.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"),
                    attempt.Allowed ? "[ALLOW]" : "[DENY] ",
                    attempt.Ip));
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
            WhitelistStore.StateChanged -= OnStateChanged;
            base.OnFormClosed(e);
        }
    }
}
