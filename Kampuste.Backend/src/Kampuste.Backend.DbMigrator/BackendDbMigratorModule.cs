using Kampuste.Backend.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Kampuste.Backend.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BackendEntityFrameworkCoreModule),
    typeof(BackendApplicationContractsModule)
    )]
public class BackendDbMigratorModule : AbpModule
{
}
