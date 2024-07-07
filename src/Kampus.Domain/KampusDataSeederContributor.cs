using Kampus.PostQuotes;
using Kampus.PostReplies;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;

namespace Kampus;

public class KampusDataSeederContributor(
    IRepository<Post, Guid> postRepository,
    IRepository<PostQuote, Guid> postQuoteRepository,
    IRepository<PostReply, Guid> postReplyRepository,
    IIdentityUserRepository identityUserRepository)
    : IDataSeedContributor, ITransientDependency
{
    private readonly IIdentityUserRepository _identityUserRepository = identityUserRepository;

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await postRepository.GetCountAsync() <= 0)
        {
            IdentityUser user = await _identityUserRepository.InsertAsync(
                new IdentityUser(
                    Guid.NewGuid(),
                    "pezo",
                    "pezkoraler@gmail.com",
                   null
                ));
            Guid userId = user.Id;

            //Guid userId = Guid.Parse("6FACEAD7-44C3-7291-17CB-3A139C395DFF");
            //IdentityUser user = await _identityUserRepository.GetAsync(userId);

            IdentityUser newUser = await _identityUserRepository.InsertAsync(
                new IdentityUser(
                    Guid.NewGuid(),
                    "sezo",
                    "szrakoraler@gmail.com",
                   null
                ));

            var firstPost = await postRepository.InsertAsync(
                new Post(
                    userId,
                    "Kampuste'nin ilk postu",
                    null
                ),
                autoSave: true
            );

            var secondPost = await postRepository.InsertAsync(
                new Post(
                    userId,
                    "Bu bir kampuste post'udur.",
                    null
                ),
                autoSave: true
            );

            if (await postQuoteRepository.GetCountAsync() <= 0)
            {
                PostQuote firstQuote = new PostQuote(userId, "First quote for the first post", firstPost.Id, null);
                PostQuote secondQuote = new PostQuote(newUser.Id, "Second quote for the first post", firstPost.Id, null);

                await postQuoteRepository.InsertManyAsync([firstQuote, secondQuote], autoSave: true);
            }
            if (await postReplyRepository.GetCountAsync() <= 0)
            {
                var firstReply = await postReplyRepository.InsertAsync(
                    new PostReply(userId, "first reply for the first post", firstPost.Id, null), autoSave: true);

                await postReplyRepository.InsertAsync(new PostReply(userId, "first reply to first replay", firstReply.Id, null), autoSave: true);
            }
        }

    }
}