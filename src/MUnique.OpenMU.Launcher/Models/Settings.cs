using System;
using MUnique.OpenMU.Launcher.Managers;
using Prism.Mvvm;

namespace MUnique.OpenMU.Launcher.Models
{
    public class Settings : BindableBase
    {
        private Version localVersion = Version.Parse("0.0.1.0");
        private string userName = "test";

        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        public Version LocalVersion
        {
            get => localVersion;
            set => SetProperty(ref localVersion, value);
        }

        private string primaryColor = LauncherSettingsManager.Settings.DefaultPrimaryColor;

        public string PrimaryColor
        {
            get => primaryColor;
            set => SetProperty(ref primaryColor, value);
        }

        private string accentColor = LauncherSettingsManager.Settings.DefaultAccentColor;

        public string AccentColor
        {
            get => accentColor;
            set => SetProperty(ref accentColor, value);
        }


        private bool darkMode= LauncherSettingsManager.Settings.DarkMode;

        public bool DarkMode
        {
            get => darkMode;
            set => SetProperty(ref darkMode, value);
        }
    }
}