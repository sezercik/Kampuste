using Kampus.Posts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kampus.PostReplies
{
    public class PostReplyDto : PostDto
    {
        public Guid RepliedPostId { get; set; }
    }
}
