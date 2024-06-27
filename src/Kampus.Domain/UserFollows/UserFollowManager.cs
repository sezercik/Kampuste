using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;

namespace Kampus.UserFollows
{
    public class UserFollowManager : DomainService
    {
        private readonly IUserFollowRepository _userFollowRepository;
        private readonly IIdentityUserRepository _identityUserRepository;

        public UserFollowManager(
            IUserFollowRepository userFollowRepository,
            IIdentityUserRepository identityUserRepository
            )
        {
            _userFollowRepository = userFollowRepository;
            _identityUserRepository = identityUserRepository;
        }

        public async Task<UserFollow> CreateAsync(Guid followerId, Guid followeeId)
        {
            var followeeRoles = await _identityUserRepository.GetRoleNamesAsync(followeeId) ?? ["err"];
            bool isAccountPrivate = followeeRoles.Contains("private");
            UserFolloweeType status = UserFolloweeType.Active;
            if (isAccountPrivate)
            {
                status = UserFolloweeType.Pending;
            }
            return new UserFollow(
                followerId:followerId,
                followeeId:followeeId,
                status:status
            );
        }
    }
}
