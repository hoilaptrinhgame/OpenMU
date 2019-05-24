using System;
using System.Threading.Tasks;
using System.Windows;
using MUnique.OpenMU.Launcher.Managers;
using MUnique.OpenMU.Launcher.ViewModels;

namespace MUnique.OpenMU.Launcher.Views
{
    public partial class MainView
    {
        public MainView()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            InitializeComponent();
            
            //Check for updates on the start up
            UpdateManager.CheckForUpdates();
        }

        private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exp = (Exception) e.ExceptionObject;

            MessageBox.Show(exp.ToString(), "Unexpected error.", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
        }
    }
}