using Volo.Abp.Modularity;

namespace Kampus;

/* Inherit from this class for your domain layer tests. */
public abstract class KampusDomainTestBase<TStartupModule> : KampusTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
