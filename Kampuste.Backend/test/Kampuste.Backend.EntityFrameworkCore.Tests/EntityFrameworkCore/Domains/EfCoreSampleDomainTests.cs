using Kampuste.Backend.Samples;
using Xunit;

namespace Kampuste.Backend.EntityFrameworkCore.Domains;

[Collection(BackendTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<BackendEntityFrameworkCoreTestModule>
{

}
