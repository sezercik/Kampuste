using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Kampus.UserFriendRequests
{
    public interface IUserFriendRequestRepository : IRepository<UserFriendRequest, Guid>
    {
        Task<List<UserFriendRequest>> GetSentFriendRequests(
            Guid userId,
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
            );

        Task<List<UserFriendRequest>> GetReceivedFriendRequests(
            Guid userId,
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
            );
    }
}
