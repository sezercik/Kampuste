using Volo.Abp.Modularity;

namespace Kampus;

[DependsOn(
    typeof(KampusApplicationModule),
    typeof(KampusDomainTestModule)
)]
public class KampusApplicationTestModule : AbpModule
{

}
