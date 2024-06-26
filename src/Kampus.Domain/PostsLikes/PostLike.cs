using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Kampus.PostsLikes;

public class PostLike : FullAuditedAggregateRoot<Guid>
{
    public Guid PostId { get; set; }
    public Post Post { get; set; }
    public Guid UserId { get; set; }
    public IdentityUser User { get; set; }

    protected PostLike()
    {
    }

    public PostLike(Guid postId, Guid userId)
    {
        PostId = postId;
        UserId = userId;
    }
}