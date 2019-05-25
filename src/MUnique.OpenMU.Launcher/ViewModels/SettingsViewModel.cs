using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Channels;
using System.Windows;
using System.Windows.Documents;
using MUnique.OpenMU.Launcher.Managers;
using MUnique.OpenMU.Launcher.Models;
using Prism.Mvvm;

namespace MUnique.OpenMU.Launcher.ViewModels
{
    public class SettingsViewModel : BindableBase
    {
        public Settings Settings => SettingsManager.Settings;

        public bool DevMode => ArgumentsManager.HasArgs && ArgumentsManager.ArgumentOptions.Dev;
    }
}