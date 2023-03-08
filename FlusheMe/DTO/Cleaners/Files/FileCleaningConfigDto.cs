using FlusheMe.Base;
using FlusheMe.Configuration.FileCleaning;
using FlusheMe.DTO.Directors.Base;

namespace FlusheMe.DTO.Cleaners.Files;

public class FileCleaningConfigDto : IDirectorArgument, IDeferredExecution, IAutoClearOnProcessed
{
    public FileCleaningConfigDto() { }

    public FileCleaningConfigDto(FileCleaningConfig? configModel)
    {
        DaysAwayToProcess = configModel?.DaysAwayToProcess;
        AutoClearOnProcessed = configModel?.AutoClearOnProcessed;
        FilePathsToDelete = configModel?.FilePathsToDelete?.Select(filePathConfig => new FilePathToDeleteConfigDto(filePathConfig))?.ToArray()
            ?? Array.Empty<FilePathToDeleteConfigDto>();
    }

    public int? DaysAwayToProcess { get; set; }

    public bool? AutoClearOnProcessed { get; set; }

    public FilePathToDeleteConfigDto[]? FilePathsToDelete { get; set; }
}