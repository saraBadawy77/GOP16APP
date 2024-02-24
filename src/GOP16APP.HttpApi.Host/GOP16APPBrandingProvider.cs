using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace GOP16APP;

[Dependency(ReplaceServices = true)]
public class GOP16APPBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "GOP16APP";
}
