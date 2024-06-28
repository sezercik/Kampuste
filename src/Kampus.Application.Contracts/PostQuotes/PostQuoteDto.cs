using Kampus.Posts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kampus.PostQuotes
{
    public class PostQuoteDto : PostDto
    {
        public Guid QuotedPostId { get; set; }
    }
}
