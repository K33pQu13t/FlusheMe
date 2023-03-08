using FlusheMe.DTO.Cleaners.Files;
using FlusheMe.Helpers;
using FlusheMe.Services.ResponsibilityChain;

namespace FlusheMe.Services.Handlers.Cleaners.Files;

public class FileDeletingResponsibilityChainService : ResponsibilityChainHandler
{
    public FileDeletingResponsibilityChainService(FilePathToDeleteConfigDto filePathToDeleteDto)
        : base(filePathToDeleteDto)
    {
    }

    public override void Handle()
    {
#if DEBUG
        Console.WriteLine(
            $"{nameof(FileDeletingResponsibilityChainService)}.{nameof(FileDeletingResponsibilityChainService.Handle)} rised");
#endif
        if (_argument is not FilePathToDeleteConfigDto fileConfigDto 
            || string.IsNullOrEmpty(fileConfigDto.PathToDelete)
            || (!Directory.Exists(fileConfigDto.PathToDelete) && !File.Exists(fileConfigDto.PathToDelete)))
        {
            base.Handle();
            return;
        }

        FileAttributes fileAttributes = File.GetAttributes(fileConfigDto.PathToDelete);
        // If it is file then just delete it
        if (fileAttributes != FileAttributes.Directory)
        {
            File.Delete(fileConfigDto.PathToDelete);
            base.Handle();
            return;
        }

        // If path should be also deleted, then delete it and it's content
        if (fileConfigDto.IncludeThisPathToDelete is true)
        {
            Directory.Delete(fileConfigDto.PathToDelete, true);
            base.Handle();
            return;
        }

        // Otherwise delete only all inside folder
        DirectoryHelper.DeleteAllInsideDirectory(fileConfigDto.PathToDelete);

        base.Handle();
    }
}