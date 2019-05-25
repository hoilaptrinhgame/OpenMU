using System;
using System.Linq;
using System.Windows;
using MahApps.Metro.Controls;
using MUnique.OpenMU.Launcher.Managers;
using MUnique.OpenMU.Launcher.ViewModels;
using NLog;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Unity;

namespace MUnique.OpenMU.Launcher.Views
{
    public partial class MainView : MetroWindow
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        
        IContainerExtension _container;
        IRegionManager _regionManager;
        private IRegion pageRegion;


        public MainView(IContainerExtension container, IRegionManager regionManager)
        {
            //TODO Remove
            logger.Log(LogLevel.Info, "Test");

            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            
            InitializeComponent();
            
            _container = container;
            _regionManager = regionManager;

            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(SettingsView));

            //Check for updates on the start up
            UpdateManager.CheckForUpdates();
        }

        private void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exp = (Exception) e.ExceptionObject;

            logger.Log(LogLevel.Error, exp, "Unhandled error.");
            MessageBox.Show(exp.ToString(), "Unexpected error.", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);
        }
    }
}