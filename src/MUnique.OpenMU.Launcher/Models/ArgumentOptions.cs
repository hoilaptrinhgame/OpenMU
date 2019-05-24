using CommandLine;

namespace MUnique.OpenMU.Launcher.Models
{
    public class ArgumentOptions
    {
        [Option('a', "autoStart", Required = false, HelpText = "Auto starts the game after the update process.")]
        public bool AutoStart { get; set; }
        
        [Option('i', "ip", Required = false, HelpText = "IP address of the main game server.")]
        public bool IP { get; set; }
        
        [Option('p', "port", Required = false, HelpText = "Port address of the main game server.")]
        public int Port { get; set; }
    }
}