using FlusheMe.DTO;
using FlusheMe.DTO.Cleaners.Browsers;
using FlusheMe.DTO.Cleaners.Files;
using FlusheMe.DTO.Executors;
using FlusheMe.Configuration;
using FlusheMe.Services.Directors;
using FlusheMe.Services.ResponsibilityChain;

namespace FlusheMe.Services;

public class FlushService
{
    private readonly BrowserCleaningDirectorService _browserCleanerService = new();
    private readonly AppExecutionDirectorService _appExecutionService = new();
    private readonly FileCleaningDirectorService _fileCleanerDirectorService = new();
    private readonly ConfigCleaningDirectorService _configCleaningDirectorService = new();

    public void Flush()
    {
        ContextConfig contextConfig = ContextConfig.GetInstance();
        AppConfig appConfig = contextConfig.GetCurrentConfig();

        ResponsibilityChainHandler finalChain = new();
        ResponsibilityChainHandler? browserCleaningChain = _browserCleanerService.GetChain(new BrowserCleaningConfigDto(appConfig.BrowserCleaningConfig));
        ResponsibilityChainHandler? appExecutionChain = _appExecutionService.GetChain(new AppExecutionConfigDto(appConfig.AppExecutionConfig));
        ResponsibilityChainHandler? fileCleaningChain = _fileCleanerDirectorService.GetChain(new FileCleaningConfigDto(appConfig.FileCleaningConfig));
        ResponsibilityChainHandler? cleanConfigChain = _configCleaningDirectorService.GetChain(new AppConfigDto(appConfig));

        finalChain.AddHandlerToEndOfChain(browserCleaningChain);
        finalChain.AddHandlerToEndOfChain(appExecutionChain);
        finalChain.AddHandlerToEndOfChain(fileCleaningChain);
        finalChain.AddHandlerToEndOfChain(cleanConfigChain);

        finalChain?.Handle();

        appConfig.LastRunDate = DateTime.Now;
        ContextConfig.SetConfig(appConfig);
    }
}