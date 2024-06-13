using System;
using Kampus.Users;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;
using Volo.Abp.Users;

namespace Kampus;

public static class KampusDtoExtensions
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        OneTimeRunner.Run(() =>
        {
            /* You can add extension properties to DTOs
             * defined in the depended modules.
             *
             * Example:
             *
             * ObjectExtensionManager.Instance
             *   .AddOrUpdateProperty<IdentityRoleDto, string>("Title");
             *
             * See the documentation for more:
             * https://docs.abp.io/en/abp/latest/Object-Extensions
             */
            // ObjectExtensionManager.Instance
            // .AddOrUpdateProperty<string>(
            //     new[]
            //     {
            //         typeof(IdentityUserDto),
            //         typeof(ProfileDto),
            //         typeof(UserData),
            //         typeof(UpdateProfileDto),
            //         typeof(RegisterDto),
            //         typeof(IdentityUserCreateDto),
            //         typeof(IdentityUserUpdateDto)
            //     },
            //     UserConsts.TcKimlikNoPropertyName
            // );
            ObjectExtensionManager.Instance
                .AddOrUpdateProperty<string>(
                    new[]
                    {
                        typeof(IdentityUserDto),
                    },
                    UserConsts.TcKimlikNoPropertyName
                );
            ObjectExtensionManager.Instance
                .AddOrUpdateProperty<string>(
                    new[]
                    {
                        typeof(IdentityUserDto),
                        typeof(ProfileDto),
                        typeof(UserData),
                        typeof(CustomUpdateProfileDto),
                        typeof(RegisterDto),
                        typeof(IdentityUserCreateDto),
                        typeof(IdentityUserUpdateDto)
                    },
                    UserConsts.UniversityEmailPropertyName
                );
         
            ObjectExtensionManager.Instance
                .AddOrUpdateProperty<DateTime>(
                    new[]
                    {
                        typeof(IdentityUserDto),
                        typeof(ProfileDto),
                        typeof(UserData),
                        typeof(CustomUpdateProfileDto),
                        typeof(RegisterDto),
                        typeof(IdentityUserCreateDto),
                        typeof(IdentityUserUpdateDto)
                    },
                    UserConsts.BirthDatePropertyName
                );
           
        });
    }
}
