using FlusheMe.DTO.Executors;

namespace FlusheMe.Configuration.AppExecution;

public class RunConfig
{
    public RunConfig() { }

    public RunConfig(RunConfigDto? runConfigDto = null)
    {
        Path = runConfigDto?.AppPath;
        Arguments = runConfigDto?.Arguments;
    }

    /// <summary>
    /// Path to application to run, directory to open (network directory), url to open in browser, etc...
    /// </summary>
    public string? Path { get; set; }

    /// <summary>
    /// Run arguments
    /// </summary>
    public IEnumerable<string>? Arguments { get; set; }
}