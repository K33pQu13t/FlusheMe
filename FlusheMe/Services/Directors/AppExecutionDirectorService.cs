using FlusheMe.DTO.Executors;
using FlusheMe.Extensions.Configuration;
using FlusheMe.Services.Directors.Base;
using FlusheMe.Services.Handlers.Executors;
using FlusheMe.Services.ResponsibilityChain;

namespace FlusheMe.Services.Directors;

public class AppExecutionDirectorService : IResponsibilityChainHandlerDirector<AppExecutionConfigDto>
{
    /// <summary>
    /// Get chain to execute some files with possibility to pass arguments
    /// </summary>
    /// <param name="configDto"></param>
    /// <returns></returns>
    public ResponsibilityChainHandler? GetChain(AppExecutionConfigDto configDto)
    {
        if (configDto == null || configDto.RunConfigs == null)
        {
            return null;
        } 

        if (!configDto.IsItTimeToExecute())
        {
            return null;
        }

        ResponsibilityChainHandler chainHandler = new();
        foreach (var runConfig in configDto.RunConfigs)
        {
            chainHandler.AddHandlerToEndOfChain(new RunAppResponsibilityChainService(runConfig));
        }

        return chainHandler;
    }
}