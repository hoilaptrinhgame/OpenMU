using System;
using MUnique.OpenMU.Launcher.Enumerations;
using MUnique.OpenMU.Launcher.Interfaces;
using MUnique.OpenMU.Launcher.Models;
using MUnique.OpenMU.Launcher.Models.Updaters;
using NLog;

namespace MUnique.OpenMU.Launcher.Managers
{
    public static class UpdateManager
    {
        public delegate void OnDownloadCompleteDelegate(DownloadTask task);

        public delegate void OnProgressChangedDelegate(int progress);
        
        public delegate void OnStatusChangeDelegate(string status, bool indeterminated, bool finished);

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private static readonly IUpdater updater;

        static UpdateManager()
        {
            switch (LauncherSettingsManager.Settings.UpdaterType)
            {
                case UpdaterTypes.HTTPS:
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

        public static int TotalProgress => updater.TotalProgress;

        public static void CheckForUpdates()
        {
            try
            {
                updater.CheckForUpdates();
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e);
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
                logger.Log(LogLevel.Error, e);
            }
        }

        public static event OnDownloadCompleteDelegate OnDownloadComplete;
        public static event OnProgressChangedDelegate OnProgressChanged;
        public static event OnStatusChangeDelegate OnStatusChange;
        
        public static void NotifyStatusChange(string status, bool indeterminated = false, bool finished = false)
        {
            try
            {
                OnStatusChange?.Invoke(status, indeterminated, finished);
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e, "Failed to notify status change.");
            }
        }

        public static void NotifyDownloadComplete(DownloadTask task)
        {
            try
            {
                OnDownloadComplete?.Invoke(task);
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e, "Failed to notify download complete.");
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
                logger.Log(LogLevel.Error, e);
            }
        }
    }
}