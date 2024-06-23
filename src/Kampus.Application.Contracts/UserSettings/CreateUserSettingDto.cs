using System;
using Volo.Abp.Application.Dtos;

namespace Kampus.UserSettings;

public class CreateUserSettingDto : EntityDto<Guid>
{
    public Guid UserId { get; set; }
    public string PrivacySettings { get; set; }
    public string ThemeColor { get; set; }
    public string Language { get; set; }
}