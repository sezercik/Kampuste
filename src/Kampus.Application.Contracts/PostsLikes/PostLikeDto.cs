using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Kampus.PostsLikes
{
    public class PostLikeDto : FullAuditedEntityDto<Guid>
    {
        public virtual Guid UserId { get; set; }
        public virtual Guid PostId { get; set; }
    }
}
