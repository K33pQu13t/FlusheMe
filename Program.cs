using FlusheMe.Configuration;
using FlusheMe.Extensions.Console;
using FlusheMe.Extensions.Console.Dto;
using FlusheMe.Services;

namespace FlusheMe;

internal class Program
{
    static void Main(string[] args)
    {
        // Recreate config file if it was deleted
        var contextConfig = ContextConfig.GetInstance();

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
        string baseMessage = "no actions would be performed.\n" +
                $"Use --perform or -p argument to perform actions. " +
                $"See {linkToReadMe} to find out how to configure actions";

        if (args.Length is 0)
        {
            PrettyConsole.Write($"No args passed, {baseMessage}", writeOptions);

            return;
        }

        if (!args.Contains("--perform") && !args.Contains("-p"))
        {
            PrettyConsole.Write($"No --perform flag specified, {baseMessage}", writeOptions);

            return;
        }

        if (args.Contains("--force") || args.Contains("-f"))
        {
            contextConfig.IsForcePerform = true;
        }

        FlushService _flushService = new FlushService();
        _flushService.Flush();
    }
}