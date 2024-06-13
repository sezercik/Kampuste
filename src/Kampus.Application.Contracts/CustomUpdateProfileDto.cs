using Kampus.Users;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.Validation;

namespace Kampus;

public class CustomUpdateProfileDto:UpdateProfileDto
{
    [DynamicStringLength(typeof(UserConsts), nameof(UserConsts.MaxTcKimlikNoLength))]
    public string TcKimlikNo { get; set; }
    [DynamicStringLength(typeof(UserConsts), nameof(UserConsts.MaxUniversityEmailLength))]
    public string UniversityEmail { get; set; }
    public string BirthDate { get; set; }
}