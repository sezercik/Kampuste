using Xunit;

namespace Kampus.EntityFrameworkCore;

[CollectionDefinition(KampusTestConsts.CollectionDefinitionName)]
public class KampusEntityFrameworkCoreCollection : ICollectionFixture<KampusEntityFrameworkCoreFixture>
{

}
