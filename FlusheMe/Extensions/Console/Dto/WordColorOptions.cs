namespace FlusheMe.Extensions.Console.Dto;

public class WordColorOptions
{
    public string[] StringsToFullMatch { get; set; }

    public bool IsCaseSensitive { get; set; } = true;

    public ConsoleColor? ForegroundColor { get; set; }

    public ConsoleColor? BackgroundColor { get; set; }
}
