using Volo.Abp.Modularity;

namespace GOP16APP;

[DependsOn(
    typeof(GOP16APPDomainModule),
    typeof(GOP16APPTestBaseModule)
)]
public class GOP16APPDomainTestModule : AbpModule
{

}
