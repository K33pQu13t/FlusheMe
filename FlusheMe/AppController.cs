using FlusheMe.Configuration;
using FlusheMe.Extensions.Console;
using FlusheMe.Extensions.Console.Dto;
using FlusheMe.Services;

namespace FlusheMe.FlusheMe;

/// <summary>
/// Provides application endpoints
/// </summary>
internal static class AppController
{
    /// <summary>
    /// Run application workflow according to arguments
    /// </summary>
    /// <param name="args"></param>
    public static void Run(params string[] args)
    {
        const string linkToReadMe = "https://github.com/K33pQu13t/FlusheMe/README.md";
        WriteOptions writeOptions = new()
        {
            WordColorOptions = new List<WordColorOptions>()
            {
                new WordColorOptions()
                {
                    StringsToFullMatch = new string[] {"--perform", "-p"},
                    ForegroundColor = ConsoleColor.DarkYellow
                },
                new WordColorOptions()
                {
                    StringsToFullMatch = new string[] {linkToReadMe},
                    ForegroundColor = ConsoleColor.DarkMagenta
                },
            }
        };
        string baseNoActionMessage = $"no actions would be performed.{Environment.NewLine}" +
                $"Use --perform or -p argument to perform actions. " +
                $"See {linkToReadMe} to find out how to configure actions";

        if (args.Length is 0)
        {
            PrettyConsole.Write($"No args passed, {baseNoActionMessage}", writeOptions);
            Exit();
        }

        if (!args.Contains("--perform") && !args.Contains("-p"))
        {
            PrettyConsole.Write($"No --perform flag specified, {baseNoActionMessage}", writeOptions);
            Exit();
        }

        if (args.Contains("--force") || args.Contains("-f"))
        {
            ContextConfig.GetInstance().IsForcePerform = true;
        }

        FlusheService _flushService = new();
        _flushService.Flushe();

        Exit();
    }

    /// <summary>
    /// Exit application. Asks before exit if windows is shown
    /// </summary>
    private static void Exit()
    {
        if (ContextConfig.GetInstance().IsConsoleShown)
        {
            Console.WriteLine($"{Environment.NewLine}Press any key to exit...");
            Console.ReadKey();
        }

        Environment.Exit(0);
    }
}
