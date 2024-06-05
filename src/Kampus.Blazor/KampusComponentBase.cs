using Kampus.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Kampus.Blazor;

public abstract class KampusComponentBase : AbpComponentBase
{
    protected KampusComponentBase()
    {
        LocalizationResource = typeof(KampusResource);
    }
}
