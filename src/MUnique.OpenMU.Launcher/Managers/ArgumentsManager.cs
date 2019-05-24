using System;
using System.Linq;
using CommandLine;
using MUnique.OpenMU.Launcher.Models;

namespace MUnique.OpenMU.Launcher.Managers
{
    public static class ArgumentsManager
    {
        public static bool HasArgs { get; private set; }

        public static ArgumentOptions ArgumentOptions { get; private set; }
        
        static ArgumentsManager()
        {
            var args = Environment.GetCommandLineArgs();

            if (!args.Any())
            {
                return;
            }

            HasArgs = true;
                
            Parser.Default.ParseArguments<ArgumentOptions>(args)
                .WithParsed<ArgumentOptions>(o => { ArgumentOptions = o; });
        }
    }
}