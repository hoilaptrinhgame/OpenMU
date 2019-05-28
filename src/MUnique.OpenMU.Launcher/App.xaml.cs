using System.Windows;
using MUnique.OpenMU.Launcher.Views;
using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;

namespace MUnique.OpenMU.Launcher
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }
    }
}