using Kampus.Samples;
using Xunit;

namespace Kampus.EntityFrameworkCore.Domains;

[Collection(KampusTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<KampusEntityFrameworkCoreTestModule>
{

}
