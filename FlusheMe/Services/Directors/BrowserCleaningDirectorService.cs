using FlusheMe.DTO.Cleaners.Browsers;
using FlusheMe.Extensions.Configuration;
using FlusheMe.Services.Directors.Base;
using FlusheMe.Services.Handlers.Cleaners.Browser;
using FlusheMe.Services.ResponsibilityChain;

namespace FlusheMe.Services.Directors;

public class BrowserCleaningDirectorService : IResponsibilityChainHandlerDirector<BrowserCleaningConfigDto>
{
    /// <summary>
    /// Get chain to clean browsers data
    /// </summary>
    /// <param name="configDto"></param>
    /// <returns></returns>
    public ResponsibilityChainHandler? GetChain(BrowserCleaningConfigDto configDto)
    {
        if (configDto == null)
        {
            return null;
        }

        if (!configDto.IsItTimeToExecute())
        {
            return null;
        }

        ResponsibilityChainHandler chainHandler = new();
        if (configDto.CleanFirefox is true)
        {
            chainHandler.AddHandlerToEndOfChain(new FirefoxCleaningResponsibilityChainService());
        }
        if (configDto.CleanGoogleChrome is true)
        {
            chainHandler.AddHandlerToEndOfChain(new ChromeCleaningResponsibilityChainService());
        }

        return chainHandler;
    }
}