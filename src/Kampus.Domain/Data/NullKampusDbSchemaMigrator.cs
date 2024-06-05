using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Kampus.Data;

/* This is used if database provider does't define
 * IKampusDbSchemaMigrator implementation.
 */
public class NullKampusDbSchemaMigrator : IKampusDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
