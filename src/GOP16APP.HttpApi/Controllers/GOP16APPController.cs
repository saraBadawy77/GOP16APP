using GOP16APP.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace GOP16APP.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class GOP16APPController : AbpControllerBase
{
    protected GOP16APPController()
    {
        LocalizationResource = typeof(GOP16APPResource);
    }
}
