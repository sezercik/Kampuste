using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kampus.PostQuotes
{
    public class CreatePostQuoteDto
    {
        [Required]
        public Guid QuotedPostId { get; set; }
        [Required]
        public string Content { get; set; }
        public string[]? BlobNames { get; set; }
    }
}
