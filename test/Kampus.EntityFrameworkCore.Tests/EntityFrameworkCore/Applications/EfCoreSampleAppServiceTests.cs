using Kampus.Samples;
using Xunit;

namespace Kampus.EntityFrameworkCore.Applications;

[Collection(KampusTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<KampusEntityFrameworkCoreTestModule>
{

}
