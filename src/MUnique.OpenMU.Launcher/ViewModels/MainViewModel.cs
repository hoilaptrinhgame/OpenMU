using System.Diagnostics;
using System.Windows.Input;
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

        public void OpenGithubURL()
        {
            Process.Start("https://github.com/MUnique/OpenMU");
        }
    }
}