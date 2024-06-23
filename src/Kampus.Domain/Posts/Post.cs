using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Kampus;

public class Post :  FullAuditedAggregateRoot<Guid>
{
    public virtual Guid UserId { get; protected set; }
        public virtual IdentityUser User { get; protected set; }
    
    //TODO: first implement the file upload system
}