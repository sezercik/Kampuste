using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Kampus.UserSettings;

public class UserSettingManager : DomainService
{
    private readonly IUserSettingRepository _userSettingRepository;

    public UserSettingManager(IUserSettingRepository userSettingRepository)
    {
        _userSettingRepository = userSettingRepository;
    }

    public async Task<UserSetting> FindByUserId(Guid userId)
    {
        var userSettings = await _userSettingRepository.FindByUserId(userId);
        return userSettings;
    }

    public async Task<UserSetting> CreateAsync(
        Guid userId,
        string privacySettings,
        string themeColor,
        string language
    )
    {
        var existinUserSettings = await _userSettingRepository.FindByUserId(userId);
        if (existinUserSettings != null)
        {
            throw new Exception("Ayar var");
        }

        return new UserSetting(
            GuidGenerator.Create(),
            userId,
            privacySettings,
            themeColor,
            language
        );
    }
}