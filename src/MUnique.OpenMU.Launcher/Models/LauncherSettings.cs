using MUnique.OpenMU.Launcher.Enumerations;
using Prism.Mvvm;

namespace MUnique.OpenMU.Launcher.Models
{
    public class LauncherSettings : BindableBase
    {
        private string defaultAccentColor = "lightblue";
        private string iconPath = "icon.ico";

        private string name = "TestName";

        private UpdaterTypes updaterType = UpdaterTypes.HTTPS;

        public string IconPath
        {
            get => iconPath;
            set => SetProperty(ref iconPath, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string DefaultAccentColor
        {
            get => defaultAccentColor;
            set => SetProperty(ref defaultAccentColor, value);
        }

        public UpdaterTypes UpdaterType
        {
            get => updaterType;
            set => SetProperty(ref updaterType, value);
        }

        private string defaultPrimaryColor = "blue";

        public string DefaultPrimaryColor
        {
            get => defaultPrimaryColor;
            set => SetProperty(ref defaultPrimaryColor, value);
        }

        private bool darkMode = true;

        public bool DarkMode
        {
            get => darkMode;
            set => SetProperty(ref darkMode, value);
        }
    }
}