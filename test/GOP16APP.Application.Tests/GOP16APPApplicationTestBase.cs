using Volo.Abp.Modularity;

namespace GOP16APP;

public abstract class GOP16APPApplicationTestBase<TStartupModule> : GOP16APPTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
