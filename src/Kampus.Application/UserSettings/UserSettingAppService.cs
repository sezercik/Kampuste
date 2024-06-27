using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace Kampus.UserSettings;

public class UserSettingAppService : ApplicationService, IUserSettingAppService
{
    private readonly IUserSettingRepository _userSettingRepository;
    private readonly UserSettingManager _userSettingManager;
    private readonly ICurrentUser _currentUser;
    public UserSettingAppService(
        IUserSettingRepository userSettingRepository, 
        UserSettingManager userSettingManager,
        ICurrentUser currentUser
        )
    {
        _userSettingRepository = userSettingRepository;
        _userSettingManager = userSettingManager;
        _currentUser = currentUser;
    }

    [Authorize]
    public async Task<UserSettingDto> CreateAsync(CreateUserSettingDto input)
    {
        if (_currentUser.IsAuthenticated)
        {
            Guid userId = _currentUser.Id ?? Guid.Empty;
            var userSettings = await _userSettingManager.CreateAsync(userId, input.PrivacySettings, input.ThemeColor, input.Language);
            await _userSettingRepository.InsertAsync(userSettings);
            return ObjectMapper.Map<UserSetting, UserSettingDto>(userSettings);
        }
        return null;   
    }
    public async Task<UserSettingDto> FindByUserId(Guid userId)
    {
        var settings = await _userSettingRepository.FirstOrDefaultAsync(us => us.UserId == userId);
        return ObjectMapper.Map<UserSetting, UserSettingDto>(settings);
    }

    [Authorize]
    public async Task UpdateUserSettingsAsync(UpdateUserSettingDto input)
    {
        if (_currentUser.IsAuthenticated)
        {
            Guid userId = _currentUser.Id ?? Guid.Empty;
            var settings = await _userSettingRepository.FirstOrDefaultAsync(us => us.UserId == userId);

            if (settings == null)
            {
                settings = new UserSetting(Guid.NewGuid(), userId, input.PrivacySettings, input.ThemeColor, input.Language);
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
}