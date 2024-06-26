using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Kampus.UserFollows
{
    public class UserFollow : FullAuditedAggregateRoot<Guid>
    {
        public Guid FollowerId { get; set; }
        public virtual IdentityUser Follower { get; set; }

        public Guid FolloweeId { get; set; }
        public virtual IdentityUser Followee { get; set; }

        protected UserFollow() { }

        public UserFollow(Guid followerId, Guid followeeId)
        {
            FollowerId = followerId;
            FolloweeId = followeeId;
        }
    }
}
