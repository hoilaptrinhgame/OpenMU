using System;
using System.Threading.Tasks;
using MUnique.OpenMU.Launcher.Enumerations;
using MUnique.OpenMU.Launcher.Interfaces;
using MUnique.OpenMU.Launcher.Models;
using MUnique.OpenMU.Launcher.Models.Updaters;
using NLog;

namespace MUnique.OpenMU.Launcher.Managers
{
    public static class UpdateManager
    {
        static UpdateManager()
        {
            switch (LauncherSettingsManager.Settings.UpdaterType)
            {
                case UpdaterTypes.HTTP:
                    updater = new HTTPSUpdater();
                    break;
                case UpdaterTypes.Torrent:
                    updater = new HTTPSUpdater();
                    break;
                case UpdaterTypes.SFTP:
                    updater = new SFTPUpdater();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        
        private static IUpdater updater;

        public static int TotalProgress => updater.TotalProgress;

        public static void CheckForUpdates()
        {
            try
            {
                updater.CheckForUpdates();
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error,e);
            }
        }

        public static async void CheckForUpdatesAsync()
        {
            try
            {
                await updater.CheckForUpdatesAsync();
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error,e);
            }
        }

        public delegate void OnDownloadCompleteDelegate(DownloadTask task);
        public delegate void OnProgressChangedDelegate(int progress);

        public static event OnDownloadCompleteDelegate OnDownloadComplete;
        public static event OnProgressChangedDelegate OnProgressChanged;

        public static void NotifyDownloadComplete(DownloadTask task)
        {
            try
            {
                OnDownloadComplete?.Invoke(task);
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error,e, "Failed to notify download complete.");
            }
        }

        public static void NotifyProgressChanged(int progress)
        {
            try
            {
                OnProgressChanged?.Invoke(progress);
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error,e);
            }
        }
    }
}