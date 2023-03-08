using FlusheMe.Base;
using FlusheMe.Configuration.BrowserCleaning;
using FlusheMe.DTO.Directors.Base;

namespace FlusheMe.DTO.Cleaners.Browsers;

public class BrowserCleaningConfigDto : IDirectorArgument, IDeferredExecution, IAutoClearOnProcessed
{
    public BrowserCleaningConfigDto() { }

    public BrowserCleaningConfigDto(BrowserCleaningConfig? configModel)
    {
        DaysAwayToProcess = configModel?.DaysAwayToProcess;
        AutoClearOnProcessed = configModel?.AutoClearOnProcessed;
        CleanFirefox = configModel?.CleanFirefox;
        CleanGoogleChrome = configModel?.CleanGoogleChrome;
    }

    public int? DaysAwayToProcess { get; set; }

    public bool? AutoClearOnProcessed { get; set; }

    public bool? CleanFirefox { get; set; } = true;

    public bool? CleanGoogleChrome { get; set; } = true;
}