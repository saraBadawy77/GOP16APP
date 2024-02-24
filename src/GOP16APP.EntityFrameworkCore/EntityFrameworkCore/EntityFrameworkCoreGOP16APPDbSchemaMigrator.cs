using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GOP16APP.Data;
using Volo.Abp.DependencyInjection;

namespace GOP16APP.EntityFrameworkCore;

public class EntityFrameworkCoreGOP16APPDbSchemaMigrator
    : IGOP16APPDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreGOP16APPDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the GOP16APPDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<GOP16APPDbContext>()
            .Database
            .MigrateAsync();
    }
}
