using System;
using Volo.Abp.Application.Dtos;

namespace Kampus.UserSettings;

public class UserSettingDto : EntityDto<Guid>
{
    public virtual Guid UserId { get; protected set; }
    public string PrivacySettings { get; set; }
    public string ThemeColor { get; set; }
    public string Language { get; set; }
}