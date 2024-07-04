using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Volo.Abp.Account;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
namespace Kampus;

public class MyUserAppService : ApplicationService, ITransientDependency
{
    public MyUserAppService(){
    }
    
   
}