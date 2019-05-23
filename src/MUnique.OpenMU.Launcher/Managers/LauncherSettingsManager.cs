using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MUnique.OpenMU.Launcher.Models;
using Newtonsoft.Json;

namespace MUnique.OpenMU.Launcher.Managers
{
    public static class LauncherSettingsManager
    {
        static LauncherSettingsManager()
        {
            LoadSettings();
        }
        public static LauncherSettings Settings;
        
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
            catch (Exception e)
            {
                //TODO proper logging
                Settings = new LauncherSettings();
            }
        }
    }
}