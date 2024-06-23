using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Kampus.UserSettings;

public class UserSettingAppService : ApplicationService, IUserSettingAppService
{
    private readonly IUserSettingRepository _userSettingRepository;
    private readonly UserSettingManager _userSettingManager;

    public UserSettingAppService(IUserSettingRepository userSettingRepository, UserSettingManager userSettingManager)
    {
        _userSettingRepository = userSettingRepository;
        _userSettingManager = userSettingManager;
    }

    public async Task<UserSettingDto> CreateAsync(CreateUserSettingDto input)
    {
        var userSettings = await _userSettingManager.CreateAsync(input.UserId, input.PrivacySettings, input.ThemeColor, input.Language);
        await _userSettingRepository.InsertAsync(userSettings);
        return ObjectMapper.Map<UserSetting, UserSettingDto>(userSettings);
    }
    public async Task<UserSettingDto> FindByUserId(Guid userId)
    {
        var settings = await _userSettingRepository.FirstOrDefaultAsync(us => us.UserId == userId);
        return ObjectMapper.Map<UserSetting, UserSettingDto>(settings);
    }

    public async Task UpdateUserSettingsAsync(UpdateUserSettingDto input)
    {
        var settings = await _userSettingRepository.FirstOrDefaultAsync(us => us.UserId == input.UserId);

        if (settings == null)
        {
            settings = new UserSetting(Guid.NewGuid(),input.UserId, input.PrivacySettings, input.ThemeColor, input.Language);
            await _userSettingRepository.InsertAsync(settings);
        }
        else
        {
            settings.PrivacySettings = input.PrivacySettings;
            settings.ThemeColor = input.ThemeColor;
            settings.Language = input.Language;
            await _userSettingRepository.UpdateAsync(settings);
        }
    }
}