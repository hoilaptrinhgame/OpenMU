using MUnique.OpenMU.Launcher.Enumerations;
using Prism.Mvvm;

namespace MUnique.OpenMU.Launcher.Models
{
    public class LauncherSettings : BindableBase
    {
        private string iconPath = "icon.ico";

        public string IconPath
        {
            get => iconPath;
            set => SetProperty(ref iconPath, value);
        }

        private string name = "TestName";

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string defaultAccentColor = "blue";

        public string DefaultAccentColor
        {
            get => defaultAccentColor;
            set => SetProperty(ref defaultAccentColor, value);
        }

        private UpdaterTypes updaterType = UpdaterTypes.HTTP;

        public UpdaterTypes UpdaterType
        {
            get => updaterType;
            set => SetProperty(ref updaterType, value);
        }
        
    }
}