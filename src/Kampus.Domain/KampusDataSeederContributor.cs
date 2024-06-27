using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Kampus;

public class KampusDataSeederContributor(
    IRepository<Post, Guid> postRepository,
    IIdentityUserRepository identityUserRepository)
    : IDataSeedContributor, ITransientDependency
{
    private readonly IIdentityUserRepository _identityUserRepository = identityUserRepository;

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await postRepository.GetCountAsync() <= 0)
        {
            Guid userId = Guid.Parse("E2721EDE-F4AF-AA82-6F8E-3A13691D7128");
            IdentityUser user = await _identityUserRepository.GetAsync(userId);
            await postRepository.InsertAsync(
                new Post(
                    Guid.NewGuid(),
                    userId,
                    "Kampuste'nin ilk postu",
                    null
                ),
                autoSave:true
            );
            
            await postRepository.InsertAsync(
                new Post(
                    Guid.NewGuid(),
                    userId,
                    "Bu bir kampuste post'udur.",
                    null
                ),
                autoSave:true
            );
        }
    }
}