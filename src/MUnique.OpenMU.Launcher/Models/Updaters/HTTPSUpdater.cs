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

            CheckingForUpdates = true;
            TotalProgress = 0;
            //Simulating the update process
            for (var i = 0; i < 100; i++)
            {
                await Task.Delay(50);
                TotalProgress++;
                UpdateManager.NotifyProgressChanged(TotalProgress);
                
            }
            
            CheckingForUpdates = false;
        }
    }
}