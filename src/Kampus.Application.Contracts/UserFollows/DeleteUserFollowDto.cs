using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kampus.UserFollows
{
    public class DeleteUserFollowDto
    {
        [Required]
        public Guid FolloweeId { get; set; }
    }
}
