using System;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using MUnique.OpenMU.Launcher.Models;
using Newtonsoft.Json;

namespace MUnique.OpenMU.Launcher.Managers
{
    public class SettingsManager
    {
        static SettingsManager()
        {
            LoadSettings();
        }
        
        public static Settings Settings;
        
        private static void LoadSettings()
        {
            if (Settings != null)
            {
                return;
            }

            try
            {
                Settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText("config.json"));
            }
            catch (Exception e)
            {
                //TODO proper logging
                Settings = new Settings();
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
                File.WriteAllText("config.json",JsonConvert.SerializeObject(Settings));
            }
            catch (Exception e)
            {
                //If the settings failed to save try again until it succeeds
                Task.Run(() =>
                {
                    Task.Delay(1000);
                    SaveSettings();
                });
            }
        }
    }
}