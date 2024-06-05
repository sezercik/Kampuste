using System;
using System.Collections.Generic;
using System.Text;
using Kampus.Localization;
using Volo.Abp.Application.Services;

namespace Kampus;

/* Inherit your application services from this class.
 */
public abstract class KampusAppService : ApplicationService
{
    protected KampusAppService()
    {
        LocalizationResource = typeof(KampusResource);
    }
}
