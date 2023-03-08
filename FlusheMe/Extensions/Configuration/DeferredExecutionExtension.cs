using FlusheMe.Base;
using FlusheMe.Configuration;

namespace FlusheMe.Extensions.Configuration;

public static class DeferredExecutionExtension
{
    /// <summary>
    /// Find out is it time to execute
    /// </summary>
    /// <param name="config">Config for any action</param>
    /// <returns>true if specified numbers of days have passed. 
    /// If config's <see cref="IDeferredExecution.DaysAwayToProcess"/> is null,
    /// then tries to get <see cref="IDeferredExecution.DaysAwayToProcess"/>
    /// from global config. If it's also null - return false</returns>
    public static bool IsItTimeToExecute(this IDeferredExecution config)
    {
        if (config == null)
        {
            return false;
        }

        ContextConfig contextConfig = ContextConfig.GetInstance();
        if (contextConfig.IsForcePerform)
        {
            return true;
        }

        AppConfig globalConfig = contextConfig.GetCurrentConfig();
        DateTime dateTimeNow = DateTime.Now;
        DateTime lastRunDate = globalConfig.LastRunDate ?? dateTimeNow;
        int? daysDifference = config.DaysAwayToProcess ?? globalConfig.DaysAwayToProcess;

        if (daysDifference is null)
        {
            return false;
        }

        if ((dateTimeNow.Date - lastRunDate.Date).Days < daysDifference)
        {
            return false;
        }

        return true;
    }
}