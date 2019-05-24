using System;
using System.Windows;
using MUnique.OpenMU.Launcher.Managers;
using NLog;

namespace MUnique.OpenMU.Launcher.Views
{
    public partial class MainView
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public MainView()
        {
            //TODO Remove
            logger.Log(LogLevel.Info, "Test");

            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            InitializeComponent();

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