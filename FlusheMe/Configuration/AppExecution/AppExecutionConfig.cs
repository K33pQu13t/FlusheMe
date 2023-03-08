using FlusheMe.Base;
using FlusheMe.DTO.Executors;

namespace FlusheMe.Configuration.AppExecution;

public class AppExecutionConfig : IDeferredExecution, IAutoClearOnProcessed
{
    public AppExecutionConfig() { }

    public AppExecutionConfig(AppExecutionConfigDto? appExecutionConfigDto = null)
    {
        DaysAwayToProcess = appExecutionConfigDto?.DaysAwayToProcess;
        AutoClearOnProcessed = appExecutionConfigDto?.AutoClearOnProcessed ?? false;
        RunConfigs = appExecutionConfigDto?.RunConfigs?.Select(runConfigDto => new RunConfig(runConfigDto))?.ToArray();
    }

    /// <summary>
    /// Base value for how much days must pass to run applications.
    /// It uses if no more common value specified.
    /// Null for never.
    /// Zero for every time
    /// </summary>
    public int? DaysAwayToProcess { get; set; }

    public bool? AutoClearOnProcessed { get; set; }

    public RunConfig[]? RunConfigs { get; set; } = Array.Empty<RunConfig>();
}