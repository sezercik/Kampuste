using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kampus.PostsLikes
{
    public class CreatePostLikeDto
    {

        [Required]
        public Guid PostId { get; set; }
    }
}
