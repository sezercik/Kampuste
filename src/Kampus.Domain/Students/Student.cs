using System;
using Volo.Abp.Identity;

namespace Kampus.Students;

public class Student : IdentityUser
{
    public string TCKimlikNo { get; set; }
    public string UniversityEmail { get; set; }
    public DateTime BirthDate { get; set; }
    // public Guid FacultyId { get;  set; }
    // public Guid DepartmentId { get;  set; }
    // public Guid GradeId { get;  set; }
    // public Guid UniversityId { get;  set; }
    // public string BlobName { get;  set; }
}