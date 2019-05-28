using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MUnique.OpenMU.Launcher.Managers;
using MUnique.OpenMU.Launcher.Models;
using MUnique.OpenMU.Launcher.Views;
using Prism.Commands;
using Prism.Mvvm;

namespace MUnique.OpenMU.Launcher.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private ICommand checkForUpdatesCommand;

        private ICommand githubButtonCommand;

        private int progress;

        private TestModel testModel;

        private UserControl content;

        public UserControl Content
        {
            get => content;
            set => SetProperty(ref content, value);
        }
        
        private HomeView HomeView = new HomeView();
        private SettingsView SettingsView = new SettingsView();
        
        public MainViewModel()
        {
            testModel = new TestModel
            {
                Message = "Hello World"
            };

            githubButtonCommand = new DelegateCommand(OpenGithubURL);
            checkForUpdatesCommand = new DelegateCommand(UpdateManager.CheckForUpdates);

            goToSettings = new DelegateCommand(() => { Content = SettingsView; });
            goToHome = new DelegateCommand(() => { Content = HomeView; });
            
            GoToHome.Execute("");

            UpdateManager.OnProgressChanged += UpdateManagerOnOnProgressChanged;
        }

        private ICommand goToHome;

        public ICommand GoToHome
        {
            get => goToHome;
            set => SetProperty(ref goToHome, value);
        }

        private ICommand goToSettings;

        public ICommand GoToSettings
        {
            get => goToSettings;
            set => SetProperty(ref goToSettings, value);
        }

        public int Progress
        {
            get => progress;
            set => SetProperty(ref progress, value);
        }

        public TestModel TestModel
        {
            get => testModel;
            set => SetProperty(ref testModel, value);
        }

        public ICommand GithubButtonCommand
        {
            get => githubButtonCommand;
            set => SetProperty(ref githubButtonCommand, value);
        }

        public ICommand CheckForUpdatesCommand
        {
            get => checkForUpdatesCommand;
            set => SetProperty(ref checkForUpdatesCommand, value);
        }

        private void UpdateManagerOnOnProgressChanged(int _progress)
        {
            Progress = _progress;
        }

        public void OpenGithubURL()
        {
            Process.Start("https://github.com/MUnique/OpenMU");
        }
    }
}