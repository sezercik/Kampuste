using Kampus.PostQuotes;
using Kampus.PostReplies;
using Kampus.PostsLikes;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Kampus;

public class Post :  FullAuditedAggregateRoot<Guid>
{
    public virtual Guid UserId { get; protected set; }
    public virtual IdentityUser User { get; protected set; }
    
    public string Content { get; set; }
    public string[]? BlobNames { get; set; }

    public ICollection<PostLike> PostLikes { get; protected set; }
    public ICollection<PostQuote> PostQuotes { get; protected set; }
    public ICollection<PostReply> PostReplies { get; protected set; }


    protected Post()
    {
    }

    public Post(Guid userId, string content,string[]? blobNames=null)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Content = content;
        BlobNames = blobNames;
        PostLikes = new List<PostLike>();
        PostQuotes = new List<PostQuote>();
        PostReplies = new List<PostReply>();
    }
}