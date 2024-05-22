using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Kampuste.Backend;

[Dependency(ReplaceServices = true)]
public class BackendBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Backend";
}
