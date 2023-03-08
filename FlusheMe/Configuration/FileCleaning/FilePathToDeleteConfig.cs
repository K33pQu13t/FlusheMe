using FlusheMe.DTO.Cleaners.Files;

namespace FlusheMe.Configuration.FileCleaning;

public class FilePathToDeleteConfig
{
    public FilePathToDeleteConfig() { }

    public FilePathToDeleteConfig(FilePathToDeleteConfigDto? filePathToDeleteConfigDto = null)
    {
        Path = filePathToDeleteConfigDto?.PathToDelete;
        IncludeThisPathToDelete = filePathToDeleteConfigDto?.IncludeThisPathToDelete ?? true;
    }

    public string? Path { get; set; }

    /// <summary>
    /// If <see cref="Path"/> is directory path, true means delete this directory too.
    /// Otherwise deletes only files and directories inside <see cref="Path"/>.
    /// No effect for file path
    /// </summary>
    public bool? IncludeThisPathToDelete { get; set; } = true;
}