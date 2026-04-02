using System;
using System.Drawing;
using System.Windows.Forms;
using Grpc.Core;
using GrpcShared.Generated;

namespace GrpcClient.Forms
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string host = txtHost.Text.Trim();
            string portText = txtPort.Text.Trim();
            string name = txtName.Text.Trim();

            if (string.IsNullOrEmpty(host) || string.IsNullOrEmpty(portText))
            {
                MessageBox.Show("Please enter host and port.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int port;
            if (!int.TryParse(portText, out port))
            {
                MessageBox.Show("Port must be a number.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string address = string.Format("{0}:{1}", host, port);
            Channel channel = new Channel(address, ChannelCredentials.Insecure);

            try
            {
                Greeter.GreeterClient stub = new Greeter.GreeterClient(channel);
                HelloRequest req = new HelloRequest { Name = name };
                HelloReply reply = stub.SayHello(req);

                txtResponse.ForeColor = Color.Black;
                txtResponse.Text = reply.Message;

                string logEntry = string.Format("[{0}] → {1} | ← {2}",
                    DateTime.Now.ToString("HH:mm:ss"), name, reply.Message);
                listBoxLog.Items.Insert(0, logEntry);
                statusLabel.Text = "Last call: OK";
            }
            catch (RpcException ex)
            {
                string errorMsg = string.Format("[{0}] {1}", ex.StatusCode, ex.Status.Detail);
                txtResponse.ForeColor = Color.Red;
                txtResponse.Text = errorMsg;

                string logEntry = string.Format("[{0}] ERROR → {1} | {2}",
                    DateTime.Now.ToString("HH:mm:ss"), name, errorMsg);
                listBoxLog.Items.Insert(0, logEntry);
                statusLabel.Text = string.Format("Last call: ERROR ({0})", ex.StatusCode);
            }
            catch (Exception ex)
            {
                txtResponse.ForeColor = Color.Red;
                txtResponse.Text = ex.Message;
                statusLabel.Text = "Last call: Exception";
            }
            finally
            {
                channel.ShutdownAsync().Wait();
            }
        }
    }
}
