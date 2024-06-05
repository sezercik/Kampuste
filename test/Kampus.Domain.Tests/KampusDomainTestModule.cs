using Volo.Abp.Modularity;

namespace Kampus;

[DependsOn(
    typeof(KampusDomainModule),
    typeof(KampusTestBaseModule)
)]
public class KampusDomainTestModule : AbpModule
{

}
