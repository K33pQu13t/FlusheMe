using System.Diagnostics;

namespace FlusheMe.FlusheMe.Helpers;

public static class ProcessHelper
{
    /// <summary>
    /// Kill all runned proccesses by name
    /// </summary>
    /// <param name="processName"></param>
    public static void KillAllProcessesByName(string processName)
    {
        Process[] processes = Process.GetProcessesByName(processName);
        foreach (Process process in processes)
        {
            try
            {
                process.Kill();
            }
            catch (Exception ex)
            {
                // TODO: potentially logging
            }
        }
    }
}