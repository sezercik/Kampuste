using Kampus.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace Kampus
{
    public class CurrentUserService : ICurrentUserService, ITransientDependency
    {
        private readonly ICurrentUser _currentUser;

        public CurrentUserService(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        public bool IsAuthenticated => _currentUser.IsAuthenticated;

        public Claim? FindClaimOfCurrentUser(string claimType)
        {
            return _currentUser.FindClaim(claimType);
        }
        public Claim[] FindClaimsOfCurrentUser(string claimType)
        {
            return _currentUser.FindClaims(claimType);
        }
        public Claim[] GetAllClaimsOfCurrentUser()
        {
            return _currentUser.GetAllClaims();
        }

        public bool IsCurrentUserInRole(string roleName)
        {
            return _currentUser.IsInRole(roleName);
        }

        public CurrentUsersDetailsDto CurrentUserWithDetails()
        {
            CurrentUsersDetailsDto userWithRoleDto = new CurrentUsersDetailsDto();
            userWithRoleDto.IsAuthenticated = _currentUser.IsAuthenticated;
            userWithRoleDto.Id = _currentUser.Id;
            userWithRoleDto.Email = _currentUser.Email;
            userWithRoleDto.EmailVerified = _currentUser.EmailVerified;
            userWithRoleDto.Name = _currentUser.Name;
            userWithRoleDto.UserName = _currentUser.UserName;
            userWithRoleDto.SurName = _currentUser.SurName;
            userWithRoleDto.PhoneNumber = _currentUser.PhoneNumber;
            userWithRoleDto.PhoneNumberVerified = _currentUser.PhoneNumberVerified;
            userWithRoleDto.TenantId = _currentUser.TenantId;
            userWithRoleDto.Roles = _currentUser.Roles;

            return userWithRoleDto;
    }
        

    }
    
}