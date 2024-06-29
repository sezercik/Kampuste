using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;

namespace Kampus.UserFriendRequests
{
    public class UserFriendRequest : FullAuditedAggregateRoot<Guid>
    {
        public Guid SenderId { get; set; }
        public virtual IdentityUser Sender { get; set; }

        public Guid ReceiverId { get; set; }
        public virtual IdentityUser Receiver { get; set; }

        public bool IsAccepted { get; set; }

        protected UserFriendRequest() { }

        public UserFriendRequest(Guid senderId, Guid receiverId)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            IsAccepted = false;
        }
    }
}
