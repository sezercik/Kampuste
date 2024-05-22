using Volo.Abp.Modularity;

namespace Kampuste.Backend;

[DependsOn(
    typeof(BackendDomainModule),
    typeof(BackendTestBaseModule)
)]
public class BackendDomainTestModule : AbpModule
{

}
