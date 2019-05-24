using System.Threading.Tasks;

namespace MUnique.OpenMU.Launcher.Interfaces
{
    public interface IUpdater
    {
        int TotalProgress { get; set; }
        bool CheckingForUpdates { get; set; }

        void CheckForUpdates();
        Task CheckForUpdatesAsync();
    }
}