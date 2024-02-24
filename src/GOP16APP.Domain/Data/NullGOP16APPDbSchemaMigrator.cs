using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace GOP16APP.Data;

/* This is used if database provider does't define
 * IGOP16APPDbSchemaMigrator implementation.
 */
public class NullGOP16APPDbSchemaMigrator : IGOP16APPDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
