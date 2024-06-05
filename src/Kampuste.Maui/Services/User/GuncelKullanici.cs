using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Users;
using Volo.Abp.Application.Services;
using Volo.Abp.Security.Claims;

namespace Kampuste.Maui.Services.User
{
    public class GuncelKullanici : IApplicationService
    {
        private readonly ICurrentPrincipalAccessor _currentPrincipalAccessor;
        public GuncelKullanici(ICurrentPrincipalAccessor currentPrincipalAccessor)
        {
            _currentPrincipalAccessor = currentPrincipalAccessor;
        }
        public void Foo()
        {
            var allClaims = _currentPrincipalAccessor.Principal.Claims.ToList();
            allClaims.Capacity = 1;

            //...
        }
    }
}
