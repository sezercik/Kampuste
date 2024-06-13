// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.Extensions.Options;
// using Volo.Abp.Account;
// using Volo.Abp.Identity;
// using Volo.Abp.Users;
//
// namespace Kampus;
//
//
// public class MyProfileAppService : ProfileAppService
// {
//     protected IdentityUserManager UserManager { get; set; }
//     protected CustomIdentityUserManager CustomUserManager { get; }
//     protected IOptions<IdentityOptions> IdentityOptions { get; }
//
//     public MyProfileAppService(
//         CustomIdentityUserManager customUserManager,
//         IdentityUserManager userManager,
//         IOptions<IdentityOptions> identityOptions):base(userManager, identityOptions)
//     {
//         CustomUserManager = customUserManager;
//     }
//
//     public virtual async Task<CustomProfileDto> GetCustomProfileAsync()
//     {
//         var currentUser = await UserManager.GetByIdAsync(CurrentUser.GetId());
//
//         return ObjectMapper.Map<IdentityUser, CustomProfileDto>(currentUser);
//     }
//     public virtual async Task<CustomProfileDto> GetCustomManagerProfile()
//     {
//         var currentUser = await CustomUserManager.GetByIdAsync(CurrentUser.GetId());
//
//         return ObjectMapper.Map<IdentityUser, CustomProfileDto>(currentUser);
//     }
//    
// }