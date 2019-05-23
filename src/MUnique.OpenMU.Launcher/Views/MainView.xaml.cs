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
            InitializeComponent();
            
            //Check for updates on the start up
            UpdateManager.CheckForUpdates();
        }
    }
}