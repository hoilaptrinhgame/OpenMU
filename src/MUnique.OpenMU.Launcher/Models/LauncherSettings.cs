using MUnique.OpenMU.Launcher.Enumerations;
using Prism.Mvvm;

namespace MUnique.OpenMU.Launcher.Models
{
    public class LauncherSettings : BindableBase
    {
        private string defaultAccentColor = "blue";
        private string iconPath = "icon.ico";

        private string name = "TestName";

        private UpdaterTypes updaterType = UpdaterTypes.HTTP;

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
    }
}