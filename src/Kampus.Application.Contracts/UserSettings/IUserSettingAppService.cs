using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Kampus.UserSettings;

public interface IUserSettingAppService  : IApplicationService
{
    Task<UserSettingDto> FindByUserId(Guid userId);
    Task<UserSettingDto> CreateAsync(CreateUserSettingDto input);
    Task UpdateUserSettingsAsync(UpdateUserSettingDto input);
}