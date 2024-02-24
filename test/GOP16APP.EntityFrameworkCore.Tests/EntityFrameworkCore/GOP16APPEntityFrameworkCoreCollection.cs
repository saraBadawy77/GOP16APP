using Xunit;

namespace GOP16APP.EntityFrameworkCore;

[CollectionDefinition(GOP16APPTestConsts.CollectionDefinitionName)]
public class GOP16APPEntityFrameworkCoreCollection : ICollectionFixture<GOP16APPEntityFrameworkCoreFixture>
{

}
