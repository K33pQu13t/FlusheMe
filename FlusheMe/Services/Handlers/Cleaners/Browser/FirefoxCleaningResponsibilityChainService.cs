using FlusheMe.FlusheMe.Helpers;
using FlusheMe.Helpers;
using FlusheMe.Services.ResponsibilityChain;

namespace FlusheMe.Services.Handlers.Cleaners.Browser;

/// <summary>
/// Service for cleaning Firefox browser data
/// </summary>
public class FirefoxCleaningResponsibilityChainService : ResponsibilityChainHandler
{
    private readonly string _profilesFolderCommonPath = $"\\Mozilla\\Firefox\\Profiles\\";

    /// <summary>
    /// Clear firefox profiles - deletes cookies, passwords, history, bookmarks, etc...
    /// </summary>
    public override void Handle()
    {
#if RELEASE
        ProcessHelper.KillAllProcessesByName("firefox");

        DirectoryHelper.DeleteAllInsideDirectory(
            $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}{_profilesFolderCommonPath}");
        DirectoryHelper.DeleteAllInsideDirectory(
            $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}{_profilesFolderCommonPath}");
        DirectoryHelper.DeleteAllInsideDirectory(
            $"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}{_profilesFolderCommonPath}");
#elif DEBUG
        Console.WriteLine("Firefox profiles would be deleted in RELEASE mode");
#endif

        base.Handle();
    }
}