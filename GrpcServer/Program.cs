using System;
using System.Threading;
using System.Windows.Forms;
using GrpcServer.Forms;
using GrpcShared;

namespace GrpcServer
{
    static class Program
    {
        private static GrpcServerHost _serverHost;

        [STAThread]
        static void Main()
        {
            WhitelistStore.Initialize();

            _serverHost = new GrpcServerHost();
            Thread serverThread = new Thread(() => _serverHost.Start());
            serverThread.IsBackground = true;
            serverThread.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            _serverHost.Stop();
        }
    }
}
