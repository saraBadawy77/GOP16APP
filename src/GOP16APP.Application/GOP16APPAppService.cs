using System;
using System.Collections.Generic;
using System.Text;
using GOP16APP.Localization;
using Volo.Abp.Application.Services;

namespace GOP16APP;

/* Inherit your application services from this class.
 */
public abstract class GOP16APPAppService : ApplicationService
{
    protected GOP16APPAppService()
    {
        LocalizationResource = typeof(GOP16APPResource);
    }
}
