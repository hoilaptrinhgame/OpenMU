using System.Threading.Tasks;
using MUnique.OpenMU.Launcher.Models;

namespace MUnique.OpenMU.Launcher.Managers
{
    public static class UpdateManager
    {
        public static int TotalProgress { get; private set; }
        
        public delegate void OnDownloadCompleteDelegate(DownloadTask task);
        public delegate void OnProgressChangedDelegate(int progress);

        public static event OnDownloadCompleteDelegate OnDownloadComplete;
        public static event OnProgressChangedDelegate OnProgressChanged;
        
        public static void CheckForUpdates()
        {
            Task.Run(CheckForUpdatesAsync);
        }

        private static bool checkingForUpdates;
        
        public static async void CheckForUpdatesAsync()
        {
            if (checkingForUpdates)
            {
                return;
            }

            checkingForUpdates = true;
            TotalProgress = 0;
            //Simulating the update process
            for (var i = 0; i < 100; i++)
            {
                await Task.Delay(50);
                TotalProgress++;
                OnProgressChanged?.Invoke(TotalProgress);
            }
            
            checkingForUpdates = false;
        }
    }
}