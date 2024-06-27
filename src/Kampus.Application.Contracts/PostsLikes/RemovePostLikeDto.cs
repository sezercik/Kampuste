using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kampus.PostsLikes
{
    public class RemovePostLikeDto
    {
        [Required]
        public Guid PostId { get; set; }
    }
}
