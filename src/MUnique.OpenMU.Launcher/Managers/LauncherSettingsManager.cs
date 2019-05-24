using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using MUnique.OpenMU.Launcher.Models;
using Newtonsoft.Json;
using NLog;

namespace MUnique.OpenMU.Launcher.Managers
{
    public static class LauncherSettingsManager
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public static LauncherSettings Settings;

        static LauncherSettingsManager()
        {
            LoadSettings();
        }

        private static void LoadSettings()
        {
            if (Settings != null)
            {
                return;
            }

            try
            {
                Settings = JsonConvert.DeserializeObject<LauncherSettings>(File.ReadAllText("launcher.json"));
            }
            catch (Exception)
            {
                //Create/Reset the launcher setting if it got broken
                Settings = new LauncherSettings();
                SaveSettings();
            }

            //Save the settings after any changes made to the object's properties
            Settings.PropertyChanged += SettingsOnPropertyChanged;
        }

        private static void SettingsOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SaveSettings();
        }

        private static void SaveSettings()
        {
            try
            {
                File.WriteAllText("config.json", JsonConvert.SerializeObject(Settings));
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Warn, "Failed to save LauncherSetting, retrying to save it again in 5 seconds ...");
                //If the settings failed to save try again until it succeeds
                Task.Run(() =>
                {
                    Task.Delay(5000);
                    SaveSettings();
                });
            }
        }
    }
}