using System;
using Prism.Mvvm;

namespace MUnique.OpenMU.Launcher.Models
{
    public class Settings : BindableBase
    {
        private Version localVersion;
        private string userName;

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
    }
}