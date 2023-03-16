using FlusheMe.Configuration;
using FlusheMe.FlusheMe;
using FlusheMe.FlusheMe.Helpers;

namespace FlusheMe;

/// <summary>
/// Sets startup conditions and runs application
/// </summary>
internal class Program
{
    static void Main(string[] args)
    {
        // Recreate config file if it was deleted
        var contextConfig = ContextConfig.GetInstance();

        if (!args.Any(arg => arg == "--silent" || arg == "-s"))
        {
            ConsoleVisabilityHelper.Show();
            contextConfig.IsConsoleShown = true;
        }

        AppController.Run(args);
    }
}