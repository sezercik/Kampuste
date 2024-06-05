using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Kampus.Blazor;

[Dependency(ReplaceServices = true)]
public class KampusBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Kampus";
}
