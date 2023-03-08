using FlusheMe.Configuration.AppExecution;
using FlusheMe.DTO.ResponsibilityChain.Base;

namespace FlusheMe.DTO.Executors;

public class RunConfigDto : IHandlerArgument
{
    public RunConfigDto() { }

    public RunConfigDto(RunConfig? config)
    {
        AppPath = config?.Path;
        Arguments = config?.Arguments;
    }

    /// <summary>
    /// Path to application to run
    /// </summary>
    public string? AppPath { get; set; }

    /// <summary>
    /// Run arguments
    /// </summary>
    public IEnumerable<string>? Arguments { get; set; } = new List<string>();
}