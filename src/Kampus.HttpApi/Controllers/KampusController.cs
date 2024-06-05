using Kampus.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Kampus.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class KampusController : AbpControllerBase
{
    protected KampusController()
    {
        LocalizationResource = typeof(KampusResource);
    }
}
