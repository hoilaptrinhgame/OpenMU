using System;
using System.Threading.Tasks;
using MUnique.OpenMU.Launcher.Interfaces;

namespace MUnique.OpenMU.Launcher.Models.Updaters
{
    public class SFTPUpdater : IUpdater
    {
        public int TotalProgress { get; set; }
        public bool CheckingForUpdates { get; set; }

        public void CheckForUpdates()
        {
            throw new NotImplementedException();
        }

        public Task CheckForUpdatesAsync()
        {
            throw new NotImplementedException();
        }
    }
}