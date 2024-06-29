using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Kampus.UserBlocks
{
    public class UserBlock : FullAuditedAggregateRoot<Guid>
    {
        public Guid UserId { get; set; }
        public virtual IdentityUser User { get; set; }

        public Guid BlockedUserId { get; set; }
        public virtual IdentityUser BlockedUser { get; set; }


        protected UserBlock()
        {

        }
        public UserBlock(Guid userId, Guid friendUserId)
        {
            UserId = userId;
            BlockedUserId = friendUserId;
        }

    }
}
