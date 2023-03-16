using FlusheMe.DTO.Cleaners.Files;
using FlusheMe.Extensions.Configuration;
using FlusheMe.Services.Directors.Base;
using FlusheMe.Services.Handlers.Cleaners.Files;
using FlusheMe.Services.ResponsibilityChain;

namespace FlusheMe.Services.Directors;

public class FileCleaningDirectorService : IResponsibilityChainHandlerDirector<FileCleaningConfigDto>
{
    /// <summary>
    /// Get chain to clean files and directories
    /// </summary>
    /// <param name="configDto"></param>
    /// <returns></returns>
    public ResponsibilityChainHandler? GetChain(FileCleaningConfigDto configDto)
    {
        if (configDto == null || configDto.FilePathsToDelete == null)
        {
            return null;
        }

        if (!configDto.IsItTimeToExecute())
        {
            return null;
        }

        ResponsibilityChainHandler chainHandler = new();
        foreach (FilePathToDeleteConfigDto filePathConfigDto in configDto.FilePathsToDelete)
        {
            chainHandler.AddHandlerToEndOfChain(new FileDeletingResponsibilityChainService(filePathConfigDto));
        }

        return chainHandler;
    }
}