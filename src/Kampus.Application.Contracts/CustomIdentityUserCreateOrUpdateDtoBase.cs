using System.ComponentModel.DataAnnotations;
using Volo.Abp.Identity;
using Volo.Abp.Validation;

namespace Kampus.Users;

public class CustomIdentityUserCreateOrUpdateDtoBase : IdentityUserCreateOrUpdateDtoBase
{
    [Required]
    [DynamicStringLength(typeof(UserConsts), nameof(UserConsts.MaxTcKimlikNoLength))]
    public string TcKimlikNo { get; set; }
    [Required]
    [DynamicStringLength(typeof(UserConsts), nameof(UserConsts.MaxUniversityEmailLength))]
    public string UniversityEmail { get; set; }
    [Required]
    public string BirthDate { get; set; }
}