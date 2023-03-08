using FlusheMe.Base;
using FlusheMe.DTO.Cleaners.Browsers;

namespace FlusheMe.Configuration.BrowserCleaning;

public class BrowserCleaningConfig : IDeferredExecution, IAutoClearOnProcessed
{
    public BrowserCleaningConfig() { }

    public BrowserCleaningConfig(BrowserCleaningConfigDto? browserCleaningConfigDto = null)
    {
        DaysAwayToProcess = browserCleaningConfigDto?.DaysAwayToProcess;
        AutoClearOnProcessed = browserCleaningConfigDto?.AutoClearOnProcessed ?? false;
        CleanFirefox = browserCleaningConfigDto?.CleanFirefox ?? true;
        CleanGoogleChrome = browserCleaningConfigDto?.CleanGoogleChrome ?? true;
    }

    /// <summary>
    /// How much days must pass to execute browser cleaning.
    /// It uses if no more common value specified.
    /// Null for never.
    /// Zero for every time
    /// </summary>
    public int? DaysAwayToProcess { get; set; }

    public bool? AutoClearOnProcessed { get; set; }

    /// <summary>
    /// Should clean Firefox data
    /// </summary>
    public bool? CleanFirefox { get; set; } = true;

    /// <summary>
    /// Should clean Google Chrome data
    /// </summary>
    public bool? CleanGoogleChrome { get; set; } = true;
}