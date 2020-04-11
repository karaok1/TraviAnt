using Squirrel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraviAnt
{
    public static class AppUpdater
    {
        public static async void RunUpdater()
        {
            try
            {
                using (var mgr = await UpdateManager.GitHubUpdateManager("https://github.com/Pengii/ArmadaCollector-bin"))
                {
                    SquirrelAwareApp.HandleEvents(
                        onInitialInstall: v => mgr.CreateShortcutForThisExe(),
                        onAppUpdate: v => mgr.CreateShortcutForThisExe(),
                        onAppUninstall: v => mgr.RemoveShortcutForThisExe());

                    await mgr.UpdateApp();
                    await mgr.CreateUninstallerRegistryEntry();
                }
            }
            catch
            {
                Bot.Log("Failed to update!", Color.Black);
            }

        }
    }
}
