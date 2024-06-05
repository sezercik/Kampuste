using Volo.Abp.Modularity;

namespace Kampus;

public abstract class KampusApplicationTestBase<TStartupModule> : KampusTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
