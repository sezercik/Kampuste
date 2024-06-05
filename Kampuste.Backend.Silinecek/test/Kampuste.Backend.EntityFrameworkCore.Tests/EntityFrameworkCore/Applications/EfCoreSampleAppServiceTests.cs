using Kampuste.Backend.Samples;
using Xunit;

namespace Kampuste.Backend.EntityFrameworkCore.Applications;

[Collection(BackendTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<BackendEntityFrameworkCoreTestModule>
{

}
