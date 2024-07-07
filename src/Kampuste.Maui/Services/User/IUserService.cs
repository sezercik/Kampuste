using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kampuste.Maui.Services.User
{
    public interface IUserService
    {
        Task<List<CurrentUsersDetailsDto>> GetUserAsync(Guid Id);
        Task<CurrentUsersDetailsDto> PutUserAsync(Guid Id);
        Task<List<CurrentUsersDetailsDto>> GetUserAsync(string filter, string sorting, int skipCount, int MaxResultCount);
        Task<CurrentUsersDetailsDto> PostUserAsync(CurrentUsersDetailsDto User);
        Task<CurrentUsersDetailsDto> DeleteUserAsync(Guid Id);
        Task<List<CurrentUsersDetailsDto>> GetUserRolesAsync(Guid Id);
        Task<List<CurrentUsersDetailsDto>> PutUserRolesAsync(Guid Id);
        Task<List<CurrentUsersDetailsDto>> GetUserByUserNameAsync(string userName);
        Task<List<CurrentUsersDetailsDto>> GetUserByEmailAsync(string email);
    }
}
