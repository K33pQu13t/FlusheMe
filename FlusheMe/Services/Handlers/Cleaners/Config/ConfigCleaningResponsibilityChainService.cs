using FlusheMe.Base;
using FlusheMe.Configuration;
using FlusheMe.DTO;
using FlusheMe.Services.ResponsibilityChain;
using System.Reflection;

namespace FlusheMe.Services.Handlers.Cleaners.Config;

public class ConfigCleaningResponsibilityChainService : ResponsibilityChainHandler
{
    public ConfigCleaningResponsibilityChainService(AppConfigDto appConfigDto)
        : base(appConfigDto)
    {
    }

    public override void Handle()
    {
        if (_argument is not AppConfigDto appConfigDto)
        {
            base.Handle();
            return;
        }
        AppConfig appConfigToUpdate = new(appConfigDto);

        // if it is set to clear whole config on any execution
        if (appConfigToUpdate.AutoClearOnProcessed == true)
        {
            ContextConfig.SetConfig(new());
            base.Handle();
            return;
        }

        // get all config properties
        PropertyInfo[] properties = typeof(AppConfig).GetProperties();

        // iterate through config properties to find clearable sections
        foreach (PropertyInfo propertyInfo in properties)
        {
            // if this section should be cleared
            if (propertyInfo.GetValue(appConfigToUpdate) is IAutoClearOnProcessed config
                && config.AutoClearOnProcessed == true)
            {
                // clean config section with setting null value
                propertyInfo.SetValue(appConfigToUpdate, null);
            }
        }

        ContextConfig.SetConfig(appConfigToUpdate);

        base.Handle();
    }
}
