using FlusheMe.Extensions.Console.Dto;

namespace FlusheMe.Extensions.Console;

public static class PrettyConsole
{
    public static void Write(string? value, ConsoleColor? foregroundColor = null)
    {
        if (value is null)
        {
            return;
        }

        if (foregroundColor is null) 
        {
            System.Console.Write(value);
            return;
        }

        ConsoleColor previousForegroundColor = System.Console.ForegroundColor;
        System.Console.ForegroundColor = foregroundColor.Value;
        System.Console.Write(value);
        System.Console.ForegroundColor = previousForegroundColor;
    }

    public static void Write(string? value, WriteOptions options)
    {
        if (value is null) 
        {
            return; 
        }

        const string newLine = "\n";
        value = value.Replace(Environment.NewLine, newLine);

        foreach(string sentence in value.Split(newLine))
        {
            foreach (string word in sentence.Replace(newLine, "").Split(' '))
            {
                // If that word has color option
                WordColorOptions wordColorOptions = options.WordColorOptions?.ToList().Find(wordColorOption =>
                    wordColorOption.StringsToFullMatch.Any(stringToFullMatch =>
                    {
                        if (wordColorOption.IsCaseSensitive)
                        {
                            return stringToFullMatch.Equals(word);
                        }
                        return stringToFullMatch.ToLower().Equals(word.ToLower());
                    }));

                if (wordColorOptions is null
                    || (wordColorOptions.ForegroundColor is null && wordColorOptions.BackgroundColor is null))
                {
                    System.Console.Write($"{word} ");
                    continue;
                }

                ConsoleColor previousForegroundColor = System.Console.ForegroundColor;
                ConsoleColor previousBackgroundColor = System.Console.BackgroundColor;
                System.Console.ForegroundColor = wordColorOptions.ForegroundColor ?? previousForegroundColor;
                System.Console.BackgroundColor = wordColorOptions.BackgroundColor ?? previousBackgroundColor;
                System.Console.Write($"{word} ");
                System.Console.ForegroundColor = previousForegroundColor;
                System.Console.BackgroundColor = previousBackgroundColor;
            }
            System.Console.Write(newLine);
        }
    }

    public static void WriteLine(string? value, ConsoleColor? foregroundColor = null)
    {
        System.Console.Write(Environment.NewLine);
        Write(value, foregroundColor);
    }

    public static void WriteLine(string? value, WriteOptions options)
    {
        System.Console.Write(Environment.NewLine);
        Write(value, options);
    }
}
