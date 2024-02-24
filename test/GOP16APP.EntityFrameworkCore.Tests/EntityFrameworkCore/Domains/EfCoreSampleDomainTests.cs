using GOP16APP.Samples;
using Xunit;

namespace GOP16APP.EntityFrameworkCore.Domains;

[Collection(GOP16APPTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<GOP16APPEntityFrameworkCoreTestModule>
{

}
