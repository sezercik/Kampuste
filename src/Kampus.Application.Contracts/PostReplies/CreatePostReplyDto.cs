using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kampus.PostReplies
{
    public class CreatePostReplyDto
    {
        [Required]
        public Guid RepliedPostId { get; set; }
        [Required]
        public string Content { get; set; }
        public string[]? BlobNames { get; set; }
    }
}
