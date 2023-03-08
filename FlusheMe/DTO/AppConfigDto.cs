using FlusheMe.Base;
using FlusheMe.Configuration;
using FlusheMe.DTO.Cleaners.Browsers;
using FlusheMe.DTO.Cleaners.Files;
using FlusheMe.DTO.Directors.Base;
using FlusheMe.DTO.Executors;
using FlusheMe.DTO.ResponsibilityChain.Base;

namespace FlusheMe.DTO;

public class AppConfigDto : IDeferredExecution, IAutoClearOnProcessed, IHandlerArgument, IDirectorArgument
{
    public AppConfigDto() { }

    public AppConfigDto(AppConfig? appConfig)
    {
        DaysAwayToProcess = appConfig?.DaysAwayToProcess ?? 5;
        AutoClearOnProcessed = appConfig?.AutoClearOnProcessed ?? false;
        LastRunDate = appConfig?.LastRunDate ?? DateTime.Now;
        BrowserCleaningConfig = new(appConfig?.BrowserCleaningConfig);
        AppExecutionConfig = new(appConfig?.AppExecutionConfig);
        FileCleaningConfig = new(appConfig?.FileCleaningConfig);
    }

    /// <summary>
    /// Default value for how much days must pass to execute all configs. 
    /// Null for never
    /// </summary>
    public int? DaysAwayToProcess { get; set; }

    /// <summary>
    /// Automatically clear WHOLE config file after executing ANY action
    /// </summary>
    public bool? AutoClearOnProcessed { get; set; }

    /// <summary>
    /// Date then last run of this program was executed
    /// </summary>
    public DateTime LastRunDate { get; set; }

    /// <summary>
    /// Config for browsers cleaning
    /// </summary>
    public BrowserCleaningConfigDto? BrowserCleaningConfig { get; set; }

    /// <summary>
    /// Config for applications executing
    /// </summary>
    public AppExecutionConfigDto? AppExecutionConfig { get; set; }

    /// <summary>
    /// Config for files and directories cleaning
    /// </summary>
    public FileCleaningConfigDto? FileCleaningConfig { get; set; }
}
