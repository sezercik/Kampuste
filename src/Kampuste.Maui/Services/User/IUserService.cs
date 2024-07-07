using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kampuste.Maui.Services.User
{
    public interface IUserService
    {
        Task<List<CurrentUsersDetailsDto>> GetPostsAsync();
        Task<CurrentUsersDetailsDto> GetPostByIdAsync(Guid UserId);
        Task<List<CurrentUsersDetailsDto>> GetPostListByUserIDAsync(Guid userId, string filter, string sorting, int skipCount, int MaxResultCount);
        Task<CurrentUsersDetailsDto> PostPostAsync(CurrentUsersDetailsDto User);
        Task<CurrentUsersDetailsDto> DeletePostAsync(Guid UserId);
    }
}
