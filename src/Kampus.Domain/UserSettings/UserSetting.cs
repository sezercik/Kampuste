using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Kampus.UserSettings;

public class UserSetting :  FullAuditedAggregateRoot<Guid>
{
    public virtual Guid UserId { get; protected set; }
    public virtual IdentityUser User { get; protected set; }

    public string PrivacySettings { get; set; }
    public string ThemeColor { get; set; }
    public string Language { get; set; }

    protected UserSetting() { }

    public UserSetting(Guid id, Guid userId, string privacySettings, string themeColor, string language)
    {
        Id = id;
        UserId = userId;
        PrivacySettings = privacySettings;
        ThemeColor = themeColor;
        Language = language;
    }
}