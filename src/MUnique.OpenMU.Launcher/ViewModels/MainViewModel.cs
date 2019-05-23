using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using MUnique.OpenMU.Launcher.Managers;
using MUnique.OpenMU.Launcher.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace MUnique.OpenMU.Launcher.ViewModels
{
    public class MainViewModel : BindableBase
    {
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

        private void UpdateManagerOnOnProgressChanged(int _progress)
        {
            Progress = _progress;
        }

        private int progress;

        public int Progress
        {
            get => progress;
            set => SetProperty(ref progress, value);
        }

        private TestModel testModel;

        public TestModel TestModel
        {
            get => testModel;
            set => SetProperty(ref testModel, value);
        }

        private ICommand githubButtonCommand;

        public ICommand GithubButtonCommand
        {
            get => githubButtonCommand;
            set => SetProperty(ref githubButtonCommand, value);
        }

        private ICommand checkForUpdatesCommand;

        public ICommand CheckForUpdatesCommand
        {
            get => checkForUpdatesCommand;
            set => SetProperty(ref checkForUpdatesCommand, value);
        }

        public void OpenGithubURL()
        {
            Process.Start("https://github.com/MUnique/OpenMU");
        }
    }
}