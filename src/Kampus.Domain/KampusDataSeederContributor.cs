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
            Guid userId = Guid.Parse("ab5d45f9-3e8f-4246-87a6-3a134dab6fdb");
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