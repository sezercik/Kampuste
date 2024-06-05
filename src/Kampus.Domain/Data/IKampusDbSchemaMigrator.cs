using System.Threading.Tasks;

namespace Kampus.Data;

public interface IKampusDbSchemaMigrator
{
    Task MigrateAsync();
}
