using Volo.Abp.Modularity;

namespace GOP16APP;

/* Inherit from this class for your domain layer tests. */
public abstract class GOP16APPDomainTestBase<TStartupModule> : GOP16APPTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
