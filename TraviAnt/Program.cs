using Fiddler;
using Squirrel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraviAnt.Proxy;

namespace TraviAnt
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppUpdater.RunUpdater();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            HelpTools.CoInternetSetFeatureEnabled();
            HelpTools.UrlMkSetSessionOption("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36");
            CertMaker.createRootCert();
            CertMaker.trustRootCert();
            StartBrowserProxy();

            Application.Run(new Form1());
        }

        public static void StartBrowserProxy()
        {
            FiddlerProxy.Start();
            WinInetInterop.SetConnectionProxy(string.Concat(new object[]
                {
                    "127.0.0.1",
                    ":",
                    "7777"
                }));
        }

        private static async void RunUpdater()
        {
            try
            {
                using (var mgr = UpdateManager.GitHubUpdateManager("https://github.com/Pengii/TraviAnt").Result)
                {
                    await mgr.UpdateApp();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error while updating: " + e.ToString());
            }
        }
    }
}
