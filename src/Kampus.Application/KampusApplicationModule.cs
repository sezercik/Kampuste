using System;
using AutoMapper;
using Kampus.Users;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.Data;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Users;

namespace Kampus;

[DependsOn(
    typeof(KampusDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(KampusApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class KampusApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<KampusApplicationModule>();
            
            options.Configurators.Add(context =>
            {
                context.MapperConfiguration.CreateMap<IdentityUser, CustomIdentityUserDto>();
                context.MapperConfiguration.CreateMap<ProfileDto, CustomProfileDto>();
                context.MapperConfiguration.CreateMap<CustomUpdateProfileDto, CustomProfileDto>();
                context.MapperConfiguration.CreateMap<IdentityUserCreateOrUpdateDtoBase, CustomProfileDto>();
                context.MapperConfiguration.CreateMap<RegisterDto, CustomRegisterDto>();

                // context.MapperConfiguration.CreateMap<CurrentUser, CurrentUserNewDetailsDto>();
            });
        });

        Configure<AbpDataFilterOptions>(options =>
        {
            options.DefaultStates[typeof(ISoftDelete)] = new DataFilterState(isEnabled: true);
        });

    }
}
