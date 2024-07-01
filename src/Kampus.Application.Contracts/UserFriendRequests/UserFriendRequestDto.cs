using System;
using System.Collections.Generic;
using System.Text;

namespace Kampus.UserFriendRequests
{
    public class UserFriendRequestDto
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public bool IsAccepted { get; set; }
    }
}
