using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kampus.Posts
{
    public class UpdatePostDto
    {
        [Required]
        public string Content { get; set; }
        public string[]? BlobNames { get; set; }
    }
}
