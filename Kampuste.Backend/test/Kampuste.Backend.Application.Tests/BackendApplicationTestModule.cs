using Volo.Abp.Modularity;

namespace Kampuste.Backend;

[DependsOn(
    typeof(BackendApplicationModule),
    typeof(BackendDomainTestModule)
)]
public class BackendApplicationTestModule : AbpModule
{

}
