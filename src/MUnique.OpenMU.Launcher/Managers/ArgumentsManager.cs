using System;
using System.Linq;
using CommandLine;
using MUnique.OpenMU.Launcher.Models;
using NLog;

namespace MUnique.OpenMU.Launcher.Managers
{
    public static class ArgumentsManager
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        static ArgumentsManager()
        {
            try
            {
                var args = Environment.GetCommandLineArgs();

                if (!args.Any())
                {
                    return;
                }

                HasArgs = true;

                Parser.Default.ParseArguments<ArgumentOptions>(args)
                    .WithParsed(o => { ArgumentOptions = o; });
            }
            catch (Exception e)
            {
                logger.Log(LogLevel.Error, e);
            }
        }

        public static bool HasArgs { get; }

        public static ArgumentOptions ArgumentOptions { get; private set; }
    }
}