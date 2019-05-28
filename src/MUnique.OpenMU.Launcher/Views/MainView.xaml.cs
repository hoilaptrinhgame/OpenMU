using System;
using System.Linq;
using System.ServiceModel.Channels;
using System.Windows;
using CommonServiceLocator;
using MahApps.Metro.Controls;
using MUnique.OpenMU.Launcher.Managers;
using MUnique.OpenMU.Launcher.ViewModels;
using NLog;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;

namespace MUnique.OpenMU.Launcher.Views
{
    public partial class MainView : MetroWindow
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        
        public MainView()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

            InitializeComponent();
            
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