using Kampus.PostsLikes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Kampus.PostReplies
{
    public class PostReply : Post
    {
        public Guid RepliedPostId { get; set; }
        public virtual Post RepliedPost { get; set; }
        protected PostReply() :base() { }

        public PostReply(Guid userId, string content, Guid repliedPostId, string[]? blobNames = null)
        : base(userId,content,blobNames)
        {
            RepliedPostId = repliedPostId;
        }
    }
}
