﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Kampus.UserFriends
{
    public interface IUserFriendRepository : IRepository<UserFriend, Guid>
    {
        Task<List<UserFriend>> GetUserFriends(
            Guid userId,
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
            );

        Task<List<UserFriend>> GetUserCloseFriends(
            Guid userId,
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
            );

        
    }
}
