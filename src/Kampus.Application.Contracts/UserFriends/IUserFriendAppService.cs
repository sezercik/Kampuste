using Kampus.UserFriendRequests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Kampus.UserFriends
{
    public interface IUserFriendAppService : IApplicationService
    {
        public Task SendFriendRequest(Guid receiverId);
        public Task AcceptFriendRequest(Guid friendRequestId);
        public Task RejectFriendRequest(Guid friendRequestId);
        public Task RemoveFriend(Guid friendId);
        public Task<PagedResultDto<UserFriendDto>> GetFriends(GetUserFriendListDto input);
        public Task<PagedResultDto<UserFriendRequestDto>> GetSentFriendRequests(GetUserFriendListDto input);
        public Task<PagedResultDto<UserFriendRequestDto>> GetReceivedFriendRequests(GetUserFriendListDto input);
        
    }
}
