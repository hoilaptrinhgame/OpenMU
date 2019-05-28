using System.Threading.Tasks;
using MUnique.OpenMU.Launcher.Interfaces;
using MUnique.OpenMU.Launcher.Managers;

namespace MUnique.OpenMU.Launcher.Models.Updaters
{
    public class HTTPSUpdater : IUpdater
    {
        public int TotalProgress { get; set; }

        public bool CheckingForUpdates { get; set; }

        public void CheckForUpdates()
        {
            Task.Run(CheckForUpdatesAsync);
        }

        public async Task CheckForUpdatesAsync()
        {
            if (CheckingForUpdates)
            {
                return;
            }
            
            UpdateManager.NotifyStatusChange("Fetching updates ...", true);

            await Task.Delay(5000);

            CheckingForUpdates = true;
            TotalProgress = 0;
            //Simulating the update process
            UpdateManager.NotifyStatusChange("Downloading files ...");
            for (var i = 0; i < 100; i++)
            {
                await Task.Delay(10);
                TotalProgress++;
                UpdateManager.NotifyProgressChanged(TotalProgress);
            }
            UpdateManager.NotifyStatusChange("Patching files ...", true);

            await Task.Delay(4000);

            UpdateManager.NotifyStatusChange("Update finished!", false, true);
            
            CheckingForUpdates = false;
        }
    }
}