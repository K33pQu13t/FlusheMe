using System.Runtime.InteropServices;

namespace FlusheMe.FlusheMe.Helpers;

/// <summary>
/// Class to manage console window visability
/// </summary>
public static class ConsoleVisabilityHelper
{
    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool AllocConsole();

    [DllImport("kernel32.dll")]
    private static extern IntPtr GetConsoleWindow();

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr windowAddressRef, int cmdShowMode);

    private enum WindowVisabilityMode
    {
        Hide = 0,
        Show = 5
    }

    /// <summary>
    /// Shows console's window
    /// </summary>
    public static void Show()
    {
        IntPtr handle = GetConsoleWindow();

        if (handle == IntPtr.Zero)
        {
            AllocConsole();
        }
        else
        {
            ShowWindow(handle, (int)WindowVisabilityMode.Show);
        }
    }

    /// <summary>
    /// Hides console's window (but it still runned)
    /// </summary>
    public static void Hide()
    {
        IntPtr handle = GetConsoleWindow();
        ShowWindow(handle, (int)WindowVisabilityMode.Hide);
    }
}