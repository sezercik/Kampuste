using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Kampus.UserFollows
{
    public interface IUserFollowRepository : IRepository<UserFollow, Guid>
    {
        Task<List<UserFollow>> GetUserFollowers(
            Guid userId,
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
            );
        Task<List<UserFollow>> GetUserFollowees(
            Guid userId,
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
            );

        Task<List<UserFollow>> GetPendingUserFollowers(
            Guid userId,
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
            );

    }
}
