using FlusheMe.DTO;
using FlusheMe.Services.Directors.Base;
using FlusheMe.Services.Handlers.Cleaners.Config;
using FlusheMe.Services.ResponsibilityChain;

namespace FlusheMe.Services.Directors;

public class ConfigCleaningDirectorService : IResponsibilityChainHandlerDirector<AppConfigDto>
{
    /// <summary>
    /// Get chain to clean this application's configs
    /// </summary>
    /// <param name="appConfigDto"></param>
    /// <returns></returns>
    public ResponsibilityChainHandler? GetChain(AppConfigDto appConfigDto)
    {
        if (appConfigDto == null)
        {
            return null;
        }

        return new ConfigCleaningResponsibilityChainService(appConfigDto);
    }
}
