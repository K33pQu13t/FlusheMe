using FlusheMe.DTO.Executors;
using FlusheMe.Services.ResponsibilityChain;
using System.Diagnostics;

namespace FlusheMe.Services.Handlers.Executors;

public class RunAppResponsibilityChainService : ResponsibilityChainHandler
{
    public RunAppResponsibilityChainService(RunConfigDto runConfigDto)
        : base(runConfigDto)
    {
    }

    public override void Handle()
    {
#if DEBUG
        Console.WriteLine(
            $"{nameof(RunAppResponsibilityChainService)}.{nameof(RunAppResponsibilityChainService.Handle)} rised");
#endif

        if (_argument is not RunConfigDto runConfigDto)
        {
            base.Handle();
            return;
        }

        Process process = new();
        process.StartInfo.FileName = runConfigDto.AppPath;
        process.StartInfo.RedirectStandardOutput = false;
        process.StartInfo.UseShellExecute = true;
        if (runConfigDto.Arguments?.Count() > 0 )
        {
            process.StartInfo.Arguments = string.Join(" ", runConfigDto.Arguments);
        }

        try
        {
            process.Start();
        }
        catch (Exception ex)
        {
            // TODO: possible log
        }

        base.Handle();
    }
}