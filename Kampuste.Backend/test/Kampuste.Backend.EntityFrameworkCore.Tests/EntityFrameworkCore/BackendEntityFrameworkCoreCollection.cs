using Xunit;

namespace Kampuste.Backend.EntityFrameworkCore;

[CollectionDefinition(BackendTestConsts.CollectionDefinitionName)]
public class BackendEntityFrameworkCoreCollection : ICollectionFixture<BackendEntityFrameworkCoreFixture>
{

}
