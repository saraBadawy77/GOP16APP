using System.Threading.Tasks;

namespace GOP16APP.Data;

public interface IGOP16APPDbSchemaMigrator
{
    Task MigrateAsync();
}
