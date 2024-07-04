using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;

namespace Kampuste.Maui.Services.Posts
{
    [Volo.Abp.DependencyInjection.Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IDenemeService))]
    public class DenemeService : IDenemeService, ITransientDependency
    {
        private readonly ICurrentPrincipalAccessor _currentPrincipalAccessor;

        public DenemeService(ICurrentPrincipalAccessor currentPrincipalAccessor)
        {
            _currentPrincipalAccessor = currentPrincipalAccessor;
        }

        public List<Claim> Foo()
        {
            var allClaims = _currentPrincipalAccessor.Principal.Claims.ToList();
            return allClaims;
        }
    }
}
