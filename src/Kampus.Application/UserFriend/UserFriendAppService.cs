using Kampus.UserFriendRequests;
using Kampus.UserFriends;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace Kampus.UserFriend
{
    public class UserFriendAppService : ApplicationService, IUserFriendAppService
    {
        private readonly IUserFriendRepository _userFriendRepository;
        private readonly IUserFriendRequestRepository _userFriendRequestRepository;
        private readonly ICurrentUser _currentUser;

        public UserFriendAppService(IUserFriendRepository userFriendRepository, ICurrentUser currentUser, IUserFriendRequestRepository userFriendRequestRepository)
        {
            _userFriendRepository = userFriendRepository;
            _currentUser = currentUser;
            _userFriendRequestRepository = userFriendRequestRepository;
        }

        [Authorize]
        public async Task AcceptFriendRequest(Guid friendRequestId)
        {
            var friendRequest = await _userFriendRequestRepository.GetAsync(friendRequestId);
            if (friendRequest.ReceiverId != _currentUser.Id)
            {
                throw new UserFriendlyException("Sadece alan kullanıcı isteği kabul edebilir!");
            }
            friendRequest.IsAccepted = true;
            await _userFriendRequestRepository.UpdateAsync(friendRequest);

            var friend = new UserFriends.UserFriend(friendRequest.SenderId, friendRequest.ReceiverId, UserFriendType.NORMAL);
            await _userFriendRepository.InsertAsync(friend, autoSave: true);

            var reverseFriend = new UserFriends.UserFriend(friendRequest.ReceiverId, friendRequest.SenderId, UserFriendType.NORMAL);
            await _userFriendRepository.InsertAsync(reverseFriend, autoSave: true);
        }

        [Authorize]
        public async Task<PagedResultDto<UserFriendDto>> GetFriends(GetUserFriendListDto input)
        {
            if (_currentUser != null)
            {
                var isAdmin = _currentUser.Roles.Any(role => role == "admin");
                if (_currentUser.Id == input.UserId || isAdmin)
                {

                    var userFriendList = await _userFriendRepository.GetUserFriends(
                        input.UserId,
                        input.SkipCount,
                        input.MaxResultCount,
                        input.Sorting,
                        input.Filter
                        );
                    var totalCount = input.Filter == null
                        ? await _userFriendRepository.CountAsync(u => u.UserId == input.UserId)
                        : await _userFriendRepository.CountAsync(
                            u => u.FriendUser.NormalizedUserName.Contains(input.Filter) && u.UserId == input.UserId);

                    return new PagedResultDto<UserFriendDto>(
                        totalCount,
                        ObjectMapper.Map<List<UserFriends.UserFriend>, List<UserFriendDto>>(userFriendList)
                        );
                        
                }
                else
                {
                    throw new UserFriendlyException("Yetkisiz işlem","401");
                }
            }
            else
            {
                throw new UserFriendlyException("Yetkisiz işlem","401");
            }
        }

        [Authorize]
        public async Task<PagedResultDto<UserFriendRequestDto>> GetReceivedFriendRequests(GetUserFriendListDto input)
        {
            if (_currentUser != null)
            {
                var isAdmin = _currentUser.Roles.Any(role => role == "admin");
                if (_currentUser.Id == input.UserId || isAdmin)
                {
                    var receivedFriendRequestList = await _userFriendRequestRepository.GetReceivedFriendRequests(
                        input.UserId,
                        input.SkipCount,
                        input.MaxResultCount,
                        input.Sorting,
                        input.Filter
                    );

                    var totalCount = input.Filter == null
                        ? await _userFriendRequestRepository.CountAsync(u => u.SenderId == input.UserId)
                        : await _userFriendRequestRepository.CountAsync(
                            u => u.Receiver.NormalizedUserName.Contains(input.Filter) && u.SenderId == input.UserId);

                    var receivedFriendRequestDtoList = ObjectMapper.Map<List<UserFriendRequest>, List<UserFriendRequestDto>>(receivedFriendRequestList);

                    return new PagedResultDto<UserFriendRequestDto>(
                        totalCount,
                        receivedFriendRequestDtoList
                    );
                }
                else
                {
                    throw new UserFriendlyException("Yetkisiz işlem", "401");
                }
            }
            else
            {
                throw new UserFriendlyException("Yetkisiz işlem", "401");
            }
        }

        [Authorize]
        public async Task<PagedResultDto<UserFriendRequestDto>> GetSentFriendRequests(GetUserFriendListDto input)
        {
            if (_currentUser != null)
            {
                var isAdmin = _currentUser.Roles.Any(role => role == "admin");
                if (_currentUser.Id == input.UserId || isAdmin)
                {
                    var sentFriendRequestList = await _userFriendRequestRepository.GetSentFriendRequests(
                        input.UserId,
                        input.SkipCount,
                        input.MaxResultCount,
                        input.Sorting,
                        input.Filter
                    );

                    var totalCount = input.Filter == null
                        ? await _userFriendRequestRepository.CountAsync(u => u.SenderId == input.UserId)
                        : await _userFriendRequestRepository.CountAsync(
                            u => u.Receiver.NormalizedUserName.Contains(input.Filter) && u.SenderId == input.UserId);

                    var sentFriendRequestDtoList = ObjectMapper.Map<List<UserFriendRequest>, List<UserFriendRequestDto>>(sentFriendRequestList);

                    return new PagedResultDto<UserFriendRequestDto>(
                       totalCount,
                       sentFriendRequestDtoList
                   );
                }
                else
                {
                    throw new UserFriendlyException("Unauthorized operation", "401");
                }
            }
            else
            {
                throw new UserFriendlyException("Unauthorized operation", "401");
            }
        }


        [Authorize]
        public async Task RejectFriendRequest(Guid friendRequestId)
        {
            var friendRequest = await _userFriendRequestRepository.GetAsync(friendRequestId);
            if (friendRequest.ReceiverId != _currentUser.Id)
            {
                throw new UserFriendlyException("Sadece alan kullanıcı isteği reddedebilir!");
            }
            await _userFriendRequestRepository.DeleteAsync(friendRequestId);

        }

        [Authorize]
        public async Task RemoveFriend(Guid friendId)
        {
            if(!_currentUser.IsAuthenticated)
            {
                throw new UserFriendlyException("Kullanıcı giriş yapmalı!", "401");
            }
            var friend = await _userFriendRepository.FirstOrDefaultAsync(f => f.UserId == _currentUser.Id.Value && f.FriendUserId == friendId);
            if (friend == null || friend.UserId != _currentUser.Id)
            {
                throw new UserFriendlyException("Sadece jullanıcı arkadaşlığı sonlandırabilir!");
            }
            await _userFriendRepository.DeleteAsync(friendId);

            var reverseFriend = await _userFriendRepository.FirstOrDefaultAsync(f => f.UserId == friend.FriendUserId && f.FriendUserId == friend.UserId);
            if (reverseFriend != null)
            {
                await _userFriendRepository.DeleteAsync(reverseFriend.Id);
            }

        }

        [Authorize]
        public async Task SendFriendRequest(Guid receiverId)
        {
            if (!_currentUser.IsAuthenticated)
            {
                throw new UserFriendlyException("Kullanıcı giriş yapmalı!", "401");
            }

            var existingRequest = await _userFriendRequestRepository.FirstOrDefaultAsync(ufr => ufr.SenderId == _currentUser.Id && ufr.ReceiverId == receiverId);
            if (existingRequest != null)
            {
                throw new UserFriendlyException("Zaten bir arkadaşlık isteği gönderdiniz!");
            }
            var friendRequest = new UserFriendRequest(_currentUser.Id ?? Guid.Empty, receiverId);
            await _userFriendRequestRepository.InsertAsync(friendRequest,autoSave:true);
        }
    }
}
