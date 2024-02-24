using GOP16APP.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace GOP16APP.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(GOP16APPEntityFrameworkCoreModule),
    typeof(GOP16APPApplicationContractsModule)
    )]
public class GOP16APPDbMigratorModule : AbpModule
{
}
