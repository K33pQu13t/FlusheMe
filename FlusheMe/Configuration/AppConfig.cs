using FlusheMe.Base;
using FlusheMe.Configuration.AppExecution;
using FlusheMe.Configuration.BrowserCleaning;
using FlusheMe.Configuration.FileCleaning;
using FlusheMe.DTO;
using FlusheMe.Services.Converters;
using System.Text.Json.Serialization;

namespace FlusheMe.Configuration;

public class AppConfig : IDeferredExecution, IAutoClearOnProcessed
{
    public AppConfig() { }

    public AppConfig(AppConfigDto? appConfigDto)
    {
        DaysAwayToProcess = appConfigDto?.DaysAwayToProcess ?? 5;
        AutoClearOnProcessed = appConfigDto?.AutoClearOnProcessed ?? false;
        LastRunDate = appConfigDto?.LastRunDate ?? DateTime.Now;
        BrowserCleaningConfig = new(appConfigDto?.BrowserCleaningConfig);
        AppExecutionConfig = new(appConfigDto?.AppExecutionConfig);
        FileCleaningConfig = new(appConfigDto?.FileCleaningConfig);
    }

    /// <summary>
    /// Default value for how much days must pass to execute all configs. 
    /// Null for never.
    /// Zero for every time
    /// </summary>
    public int? DaysAwayToProcess { get; set; } = 5;

    /// <summary>
    /// Automatically clear WHOLE config file after executing ANY action
    /// </summary>
    public bool? AutoClearOnProcessed { get; set; } = false;

    /// <summary>
    /// Date then last run of this program was executed
    /// </summary>
    [JsonConverter(typeof(NullableDateTimeJsonConverter))]
    public DateTime? LastRunDate { get; set; } = DateTime.Now;

    /// <summary>
    /// Config for browsers cleaning
    /// </summary>
    public BrowserCleaningConfig? BrowserCleaningConfig { get; set; } = new();

    /// <summary>
    /// Config for applications executing
    /// </summary>
    public AppExecutionConfig? AppExecutionConfig { get; set; } = new();

    /// <summary>
    /// Config for files and directories cleaning
    /// </summary>
    public FileCleaningConfig? FileCleaningConfig { get; set; } = new();
}