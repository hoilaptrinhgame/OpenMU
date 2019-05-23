using Prism.Mvvm;

namespace MUnique.OpenMU.Launcher.Models
{
    public class LauncherSettings : BindableBase
    {
        private string iconPath;

        public string IconPath
        {
            get => iconPath;
            set => SetProperty(ref iconPath, value);
        }

        private string name;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string defaultAccentColor;

        public string DefaultAccentColor
        {
            get => defaultAccentColor;
            set => SetProperty(ref defaultAccentColor, value);
        }
        
    }
}