using Volo.Abp.Modularity;

namespace Kampuste.Backend;

public abstract class BackendApplicationTestBase<TStartupModule> : BackendTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
