using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Kampus.UserFollows
{
    public interface IUserFollowAppService : IApplicationService
    {
        Task<PagedResultDto<UserFollowDto>> GetUserFolloweeList(GetUserFolloweeListDto input);
        Task<PagedResultDto<UserFollowDto>> GetUserFollowerList(GetUserFollowerListDto input);
        Task<PagedResultDto<UserFollowDto>> GetUserPendingFollowerList(GetPendingUserFollowerListDto input);

        Task<CustomResultDto> CreateAsync(CreateUserFollowDto input);
        Task<CustomResultDto> DeleteAsync(DeleteUserFollowDto input);
    }
}
