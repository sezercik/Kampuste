using Kampus.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Kampus
{
    public class CurrentUserAppService : ApplicationService
    {

        public bool CheckUserAuthentication()
        {
            return CurrentUser.IsAuthenticated;
        }

        public CurrentUsersDetailsDto CurrentUserWithDetails()
        {

            CurrentUsersDetailsDto userWithRoleDto = new CurrentUsersDetailsDto();
            userWithRoleDto.IsAuthenticated = CurrentUser.IsAuthenticated;
            userWithRoleDto.Id = CurrentUser.Id;
            userWithRoleDto.Email = CurrentUser.Email;
            userWithRoleDto.EmailVerified = CurrentUser.EmailVerified;
            userWithRoleDto.Name = CurrentUser.Name;
            userWithRoleDto.UserName = CurrentUser.UserName;
            userWithRoleDto.SurName = CurrentUser.SurName;
            userWithRoleDto.PhoneNumber = CurrentUser.PhoneNumber;
            userWithRoleDto.PhoneNumberVerified = CurrentUser.PhoneNumberVerified;
            userWithRoleDto.TenantId = CurrentUser.TenantId;
            userWithRoleDto.Roles = CurrentUser.Roles;

            return userWithRoleDto;
        }
    }
}