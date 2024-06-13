using System.ComponentModel.DataAnnotations;
using Kampus.Users;
using Volo.Abp.Account;
using Volo.Abp.Validation;

namespace Kampus;

public class CustomRegisterDto : RegisterDto
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