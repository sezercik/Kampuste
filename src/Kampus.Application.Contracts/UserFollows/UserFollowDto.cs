using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Kampus.UserFollows
{
    public class UserFollowDto : FullAuditedEntityDto<Guid>
    {
        public virtual Guid FollowerId { get; set; }
        public Guid FolloweeId { get; set; }
    }
}
