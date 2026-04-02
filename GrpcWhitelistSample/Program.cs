using System;
using System.Windows.Forms;

namespace GrpcWhitelistSample
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Core.WhitelistStore.Initialize();
            GrpcServer.Start();

            Application.Run(new Forms.MainForm());

            GrpcServer.Stop();
        }
    }
}
