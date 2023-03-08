using FlusheMe.Base;
using FlusheMe.DTO.Cleaners.Files;

namespace FlusheMe.Configuration.FileCleaning;

public class FileCleaningConfig : IDeferredExecution, IAutoClearOnProcessed
{
    public FileCleaningConfig() { }

    public FileCleaningConfig(FileCleaningConfigDto? fileCleaningConfigDto = null)
    {
        DaysAwayToProcess = fileCleaningConfigDto?.DaysAwayToProcess;
        AutoClearOnProcessed = fileCleaningConfigDto?.AutoClearOnProcessed ?? false;
        FilePathsToDelete = fileCleaningConfigDto?.FilePathsToDelete?.Select(FilePathDto => new FilePathToDeleteConfig(FilePathDto))?.ToArray();
    }

    /// <summary>
    /// Base value for how much days must pass to delete files.
    /// It uses if no more common value specified.
    /// Null for never.
    /// Zero for every time
    /// </summary>
    public int? DaysAwayToProcess { get; set; }

    public bool? AutoClearOnProcessed { get; set; }

    public FilePathToDeleteConfig[]? FilePathsToDelete { get; set; } = Array.Empty<FilePathToDeleteConfig>();
}