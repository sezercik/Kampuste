using System.Threading.Tasks;

namespace Kampuste.Backend.Data;

public interface IBackendDbSchemaMigrator
{
    Task MigrateAsync();
}
