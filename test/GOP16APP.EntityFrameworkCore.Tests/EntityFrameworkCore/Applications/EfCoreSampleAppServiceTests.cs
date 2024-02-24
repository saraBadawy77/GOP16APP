using GOP16APP.Samples;
using Xunit;

namespace GOP16APP.EntityFrameworkCore.Applications;

[Collection(GOP16APPTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<GOP16APPEntityFrameworkCoreTestModule>
{

}
