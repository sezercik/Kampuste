using System;
using Volo.Abp.Identity;

namespace Kampus;

public class CustomIdentityUserDto: IdentityUserDto
{
    public string TcKimlikNo { get; set; }
    public string UniversityEmail { get; set; }
    public DateTime BirthDate { get; set; }
}