using System;
using System.Collections.Generic;
using System.Text;

namespace Kampus.UserFriends
{
    public class UserFriendDto
    {
        public Guid UserId { get; set; }
        public Guid FriendUserId { get; set; }
        public UserFriendType UserFriendType { get; set; }
    }
}
