namespace FlusheMe.Helpers;

public static class DirectoryHelper
{
    /// <summary>
    /// Deletes all files and subfolders inside folder
    /// </summary>
    /// <param name="path"></param>
    public static void DeleteAllInsideDirectory(string path)
    {
        if (!Directory.Exists(path))
        {
            return;
        }

        var pathDirectoryInfo = new DirectoryInfo(path);
        foreach (DirectoryInfo directory in pathDirectoryInfo.EnumerateDirectories())
        {
            try
            {
                directory.Delete(true);
            }
            catch { }
        }

        foreach (FileInfo file in pathDirectoryInfo.EnumerateFiles())
        {
            try
            {
                file.Delete();
            }
            catch { }
        }
    }
}