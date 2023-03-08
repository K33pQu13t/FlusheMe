using FlusheMe.FlusheMe.Helpers;
using FlusheMe.Helpers;
using FlusheMe.Services.ResponsibilityChain;

namespace FlusheMe.Services.Handlers.Cleaners.Browser;

public class ChromeCleaningResponsibilityChainService : ResponsibilityChainHandler
{
    private readonly string _profilesFolderCommonPath = $"\\Google\\Chrome\\User Data";

    /// <summary>
    /// Clear firefox profiles - deletes cookies, passwords, history, bookmarks, etc...
    /// </summary>
    public override void Handle()
    {
#if RELEASE
        ProcessHelper.KillAllProcessesByName("google");

        DirectoryHelper.DeleteAllInsideDirectory(
            $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}{_profilesFolderCommonPath}");
        DirectoryHelper.DeleteAllInsideDirectory(
            $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}{_profilesFolderCommonPath}");
        DirectoryHelper.DeleteAllInsideDirectory(
            $"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}{_profilesFolderCommonPath}");
#elif DEBUG
        Console.WriteLine("Google user date would be deleted in RELEASE mode");
#endif

        base.Handle();
    }
}

