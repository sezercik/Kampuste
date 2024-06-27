using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Users;

namespace Kampus.UserFollows
{
    public class UserFollowAppService : ApplicationService, IUserFollowAppService
    {
        private readonly IUserFollowRepository _userFollowRepository;
        private readonly UserFollowManager _userFollowManager;
        private readonly ICurrentUser _currentUser;
        private readonly IIdentityUserRepository _identityUserRepository;

        public UserFollowAppService(
            IUserFollowRepository userFollowRepository, 
            UserFollowManager userFollowManager, 
            ICurrentUser currentUser,
            IIdentityUserRepository identityUserRepository
            )
        {
            _userFollowRepository = userFollowRepository;
            _userFollowManager = userFollowManager;
            _currentUser = currentUser;
            _identityUserRepository = identityUserRepository;
        }
        [Authorize]
        public async Task<CustomResultDto> CreateAsync(CreateUserFollowDto input)
        {
            var result = new CustomResultDto();
            result.IsSuccess = false;
            result.ResultCode = 201;
            result.ResultMessage = "Hata";

           bool isFolloweeUserExist = await _identityUserRepository.FindAsync(input.FolloweeId) != null ? true : false;
            if (isFolloweeUserExist && _currentUser.IsAuthenticated)
            {
                Guid followerId = _currentUser.Id ?? Guid.Empty;

                if (followerId == input.FolloweeId)
                {
                    result.ResultMessage = "Kullanıcı kendini takip edemez!";
                    return result;
                }
                var newFollow = await _userFollowManager.CreateAsync(followerId: followerId, followeeId: input.FolloweeId);
                await _userFollowRepository.InsertAsync(newFollow);
                result.IsSuccess = true;
                result.ResultCode = 200;
                result.ResultMessage = "Kullanıcı takip edildi. Durum = " + newFollow.Status.ToString();
                return result;
            }
            else
            {
                result.ResultCode = 404;
                result.ResultMessage = "Takip edilecek kullanıcı bulunamadı";
                return result;
            }
        }
        [Authorize]
        public async Task<CustomResultDto> DeleteAsync(DeleteUserFollowDto input)
        {
            var result = new CustomResultDto();
            result.IsSuccess = false;
            result.ResultCode = 201;
            result.ResultMessage = "Hata";

            Guid followerId = _currentUser.Id ?? Guid.Empty;
            var follow = await _userFollowRepository.FindAsync(uf => uf.FollowerId == followerId && uf.FolloweeId == input.FolloweeId);
            if (follow != null)
            {
                await _userFollowRepository.DeleteAsync(follow);
                result.IsSuccess = true;
                result.ResultCode = 200;
                result.ResultMessage = "Kullanıcı takipten çıkarıldı";
                return result;
            }
            else
            {
                result.ResultCode = 404;
                result.ResultMessage = "Takip edilen kullanıcı bulunamadı";
                return result;
            }
        }
        public async Task<PagedResultDto<UserFollowDto>> GetUserFolloweeList(GetUserFolloweeListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(UserFollow.CreationTime);
            }
            var followees = await _userFollowRepository.GetUserFollowees(input.UserId, input.SkipCount, input.MaxResultCount,input.Sorting,input.Filter);

            var totalCount = followees.Count();
            return new PagedResultDto<UserFollowDto>(
           totalCount,
           ObjectMapper.Map<List<UserFollow>, List<UserFollowDto>>(followees)
       );
        }
        public async Task<PagedResultDto<UserFollowDto>> GetUserFollowerList(GetUserFollowerListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(UserFollow.CreationTime);
            }
            var followers = await _userFollowRepository.GetUserFollowers(input.UserId, input.SkipCount, input.MaxResultCount, input.Sorting, input.Filter);
            var totalCount = followers.Count();
            return new PagedResultDto<UserFollowDto>(
                totalCount,
                ObjectMapper.Map<List<UserFollow>, List<UserFollowDto>>(followers)
            );
        }
        [Authorize]
        public async Task<PagedResultDto<UserFollowDto>> GetUserPendingFollowerList(GetPendingUserFollowerListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(UserFollow.CreationTime);
            }
            Guid userId = _currentUser.Id ?? Guid.Empty;
            var pendingFollowers = await _userFollowRepository.GetPendingUserFollowers(userId, input.SkipCount, input.MaxResultCount, input.Sorting, input.Filter);
            var totalCount = pendingFollowers.Count();
            return new PagedResultDto<UserFollowDto>(
                totalCount,
                ObjectMapper.Map<List<UserFollow>, List<UserFollowDto>>(pendingFollowers)
            );
        }
    }
}
