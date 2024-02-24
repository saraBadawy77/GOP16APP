using Volo.Abp.Modularity;

namespace GOP16APP;

[DependsOn(
    typeof(GOP16APPApplicationModule),
    typeof(GOP16APPDomainTestModule)
)]
public class GOP16APPApplicationTestModule : AbpModule
{

}
