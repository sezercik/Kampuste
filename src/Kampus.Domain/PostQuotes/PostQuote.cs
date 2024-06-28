using Kampus.PostsLikes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Kampus.PostQuotes
{
    public class PostQuote : Post
    {
        public Guid QuotedPostId { get; set; }
        public virtual Post QuotedPost { get; set; }
        protected PostQuote() : base() { }

        public PostQuote(Guid userId, string content, Guid quotedPostId, string[]? blobNames = null)
            : base(userId,content,blobNames)
        {
            QuotedPostId = quotedPostId;
        }
    }
}
