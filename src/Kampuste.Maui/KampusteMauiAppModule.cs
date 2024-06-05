using Kampus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;
using Volo.Abp.Users;
using Volo.Abp.VirtualFileSystem;

namespace Kampuste.Maui
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(KampusHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)

        )]
    public class KampusteMauiAppModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
           // var configuration = context.Services.GetConfiguration();
           // Configure<AbpRemoteServiceOptions>(options =>
           // {
           //     options.RemoteServices.Default = new RemoteServiceConfiguration
           //     {
           //         BaseUrl = "https://localhost:44317" // Replace with your API URL
           //     };
           //     options.RemoteServices["AbpIdentity"] = new RemoteServiceConfiguration
           //     {
           //         BaseUrl = "https://localhost:44317" // Replace with your API URL
           //     };
           // });
           // context.Services.AddHttpClientProxies(
           //    typeof(KampusteMauiAppModule).Assembly,
           //    remoteServiceConfigurationName: null
           //);
           // Configure<AbpVirtualFileSystemOptions>(options =>
           // {
           //     options.FileSets.AddEmbedded<KampusteMauiAppModule>();
           // });
        }
    }
}
