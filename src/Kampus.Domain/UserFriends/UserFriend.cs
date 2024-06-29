using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Kampus.UserFriends
{
    public class UserFriend : FullAuditedAggregateRoot<Guid>
    {
        public Guid UserId { get; set; }
        public virtual IdentityUser User { get; set; }

        public Guid FriendUserId { get; set; }
        public virtual IdentityUser FriendUser { get; set; }

        public UserFriendType UserFriendType { get; set; }

        protected UserFriend()
        {
            
        }

        public UserFriend(Guid userId, Guid friendUserId, UserFriendType userFriendType)
        {
            UserId = userId;
            FriendUserId = friendUserId;
            UserFriendType = userFriendType;
        }

    }
}
