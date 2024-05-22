using Kampuste.Backend.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Kampuste.Backend.Blazor;

public abstract class BackendComponentBase : AbpComponentBase
{
    protected BackendComponentBase()
    {
        LocalizationResource = typeof(BackendResource);
    }
}
