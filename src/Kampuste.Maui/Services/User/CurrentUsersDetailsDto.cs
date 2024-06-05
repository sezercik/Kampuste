using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kampuste.Maui
{
    public class CurrentUsersDetailsDto
    {
        public bool IsAuthenticated { get; set; }
        public Guid? Id { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberVerified { get; set; }
        public string? Email { get; set; }
        public bool EmailVerified { get; set; }
        public Guid? TenantId { get; set; }
        public string[] Roles { get; set; }
    }
}
