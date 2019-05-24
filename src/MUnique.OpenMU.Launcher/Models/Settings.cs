using System;
using Prism.Mvvm;

namespace MUnique.OpenMU.Launcher.Models
{
    public class Settings : BindableBase
    {
        private string userName;

        public string UserNam
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        private Version localVersion;

        public Version LocalVersion
        {
            get => localVersion;
            set => SetProperty(ref localVersion, value);
        }
    }
}