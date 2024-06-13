using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Volo.Abp.Account;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity;
namespace Kampus;

public class MyUserAppService : IdentityUserAppService
{
    public MyUserAppService(
            IdentityUserManager userManager,
            IIdentityUserRepository userRepository,
            IIdentityRoleRepository roleRepository,
            IOptions<IdentityOptions> identityOptions,
            IPermissionChecker permissionChecker
        ) 
        : base(userManager, userRepository, roleRepository, identityOptions, permissionChecker)
    {
    }
    
    public async Task<CustomIdentityUserDto> GetCustomAsync(Guid id)
    {
        var user = await UserRepository.GetAsync(id);
        return ObjectMapper.Map<IdentityUser, CustomIdentityUserDto>(user);
    }
}