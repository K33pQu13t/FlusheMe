using FlusheMe.Configuration.FileCleaning;
using FlusheMe.DTO.ResponsibilityChain.Base;

namespace FlusheMe.DTO.Cleaners.Files;

public class FilePathToDeleteConfigDto : IHandlerArgument
{
    public FilePathToDeleteConfigDto() { }

    public FilePathToDeleteConfigDto(FilePathToDeleteConfig? config)
    {
        PathToDelete = config?.Path;
        IncludeThisPathToDelete = config?.IncludeThisPathToDelete;
    }

    public string? PathToDelete { get; set; }

    /// <summary>
    /// If <see cref="PathToDelete"/> is folder, true means delete <see cref="PathToDelete"/> folder too.
    /// Otherwise no effect, deletes only files and folders inside <see cref="PathToDelete"/>.
    /// No effect for file path
    /// </summary>
    public bool? IncludeThisPathToDelete { get; set; }
}