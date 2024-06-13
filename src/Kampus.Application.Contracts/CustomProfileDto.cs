using System;
using Volo.Abp.Account;

namespace Kampus;

public class CustomProfileDto : ProfileDto
{
    public string TcKimlikNo { get; set; }
    public string UniversityEmail { get; set; }
    public DateTime BirthDate { get; set; }
}