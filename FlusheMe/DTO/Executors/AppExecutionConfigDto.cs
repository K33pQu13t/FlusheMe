using FlusheMe.Base;
using FlusheMe.Configuration.AppExecution;
using FlusheMe.DTO.Directors.Base;

namespace FlusheMe.DTO.Executors;

public class AppExecutionConfigDto : IDirectorArgument, IDeferredExecution, IAutoClearOnProcessed
{
    public AppExecutionConfigDto() { }

    public AppExecutionConfigDto(AppExecutionConfig? configModel)
    {
        DaysAwayToProcess = configModel?.DaysAwayToProcess;
        AutoClearOnProcessed = configModel?.AutoClearOnProcessed;
        RunConfigs = configModel?.RunConfigs?.Select(runConfig => new RunConfigDto(runConfig))?.ToArray()
            ?? Array.Empty<RunConfigDto>();
    }

    public int? DaysAwayToProcess { get; set; }

    public bool? AutoClearOnProcessed { get; set; }

    public RunConfigDto[]? RunConfigs { get; set; }
}

