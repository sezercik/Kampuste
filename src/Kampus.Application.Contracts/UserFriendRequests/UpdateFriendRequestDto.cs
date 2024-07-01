using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Kampus.UserFriendRequests
{
    public class UpdateFriendRequestDto
    {
        [Required]
        public Guid SenderId { get; private set; }
        [Required]
        public Guid ReceiverId { get; private set; }
        [Required]
        public bool IsAccepted { get; set; }
    }
}
