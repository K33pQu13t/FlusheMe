using FlusheMe.FlusheMe.Helpers;

namespace FlusheMe.Configuration;

public class ContextConfig
{
    static private ContextConfig? _instance;

    /// <summary>
    /// Name of config file
    /// </summary>
    public const string ConfigFileName = "config.json";

    /// <summary>
    /// Path to app directory
    /// </summary>
    public static string AppDirectory { get; private set; } = string.Empty;

    /// <summary>
    /// Path to app config file
    /// </summary>
    private static string ConfigFilePath => Path.Combine(AppDirectory, ConfigFileName);

    /// <summary>
    /// If true then no need to check dates to perform actions, perform them anyway
    /// </summary>
    public bool IsForcePerform { get; set; }

    /// <summary>
    /// True if console is shown
    /// </summary>
    public bool IsConsoleShown { get; set; }

    private ContextConfig() { }

    /// <summary>
    /// Get cpnfig instance
    /// </summary>
    /// <returns></returns>
    public static ContextConfig GetInstance()
    {
        if (_instance != null)
        {
            return _instance;
        }
        AppDirectory = Path.GetDirectoryName(Environment.ProcessPath) ?? string.Empty;

        if (!File.Exists(ConfigFilePath))
        {
            _instance = new ContextConfig();
            JsonSerialization.Serialize(ConfigFilePath, new AppConfig());
            return _instance;
        }

        _instance = new ContextConfig();

        return _instance;
    }

    /// <returns>Actual updated application configuration</returns>
    public AppConfig GetCurrentConfig()
    {
        AppConfig config = (AppConfig)JsonSerialization.Deserialize(ConfigFilePath, typeof(AppConfig));
        return config;
    }

    /// <summary>
    /// Saves config
    /// </summary>
    /// <param name="config"></param>
    static public void SetConfig(AppConfig config)
    {
        JsonSerialization.Serialize(ConfigFilePath, config);
    }
}