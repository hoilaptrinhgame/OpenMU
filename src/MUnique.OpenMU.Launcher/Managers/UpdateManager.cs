using System.Threading.Tasks;
using MUnique.OpenMU.Launcher.Interfaces;
using MUnique.OpenMU.Launcher.Models;
using MUnique.OpenMU.Launcher.Models.Updaters;

namespace MUnique.OpenMU.Launcher.Managers
{
    public static class UpdateManager
    {
        private static IUpdater updater = new HTTPSUpdater();

        public static int TotalProgress => updater.TotalProgress;

        public static void CheckForUpdates()
        {
            updater.CheckForUpdates();
        }

        public static async void CheckForUpdatesAsync()
        {
            await updater.CheckForUpdatesAsync();
        }

        public delegate void OnDownloadCompleteDelegate(DownloadTask task);
        public delegate void OnProgressChangedDelegate(int progress);

        public static event OnDownloadCompleteDelegate OnDownloadComplete;
        public static event OnProgressChangedDelegate OnProgressChanged;

        public static void NotifyDownloadComplete(DownloadTask task)
        {
            OnDownloadComplete?.Invoke(task);
        }

        public static void NotifyProgressChanged(int progress)
        {
            OnProgressChanged?.Invoke(progress);
        }
    }
}