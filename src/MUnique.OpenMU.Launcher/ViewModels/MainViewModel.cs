using System.Diagnostics;
using System.Windows.Input;
using MUnique.OpenMU.Launcher.Managers;
using MUnique.OpenMU.Launcher.Models;
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

        public MainViewModel()
        {
            testModel = new TestModel
            {
                Message = "Hello World"
            };

            githubButtonCommand = new DelegateCommand(OpenGithubURL);
            checkForUpdatesCommand = new DelegateCommand(UpdateManager.CheckForUpdates);

            UpdateManager.OnProgressChanged += UpdateManagerOnOnProgressChanged;
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