using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Kampus;

public class Post :  FullAuditedAggregateRoot<Guid>
{
    public virtual Guid UserId { get; protected set; }
    public virtual IdentityUser User { get; protected set; }
    
    public string Content { get; set; }
    public string[]? BlobNames { get; set; }

    protected Post()
    {
    }

    public Post(Guid id, Guid userId, string content,string[]? blobNames=null)
    {
        Id = id;
        UserId = userId;
        Content = content;
        BlobNames = blobNames;
    }
}