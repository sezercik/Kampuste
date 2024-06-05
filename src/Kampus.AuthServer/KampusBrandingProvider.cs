using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Kampus;

[Dependency(ReplaceServices = true)]
public class KampusBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Kampus";
}
