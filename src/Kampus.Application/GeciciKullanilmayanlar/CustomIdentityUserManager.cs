// using System;
// using System.Collections.Generic;
// using System.Threading;
// using System.Threading.Tasks;
// using AutoMapper.Internal.Mappers;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.Options;
// using Volo.Abp.Caching;
// using Volo.Abp.Domain.Entities;
// using Volo.Abp.EventBus.Distributed;
// using Volo.Abp.Identity;
// using Volo.Abp.Security.Claims;
// using Volo.Abp.Settings;
// using Volo.Abp.Threading;
//
// namespace Kampus;
//
// public class CustomIdentityUserManager : IdentityUserManager
// {
//     protected IIdentityRoleRepository RoleRepository { get; }
//     protected IIdentityUserRepository UserRepository { get; }
//     protected IOrganizationUnitRepository OrganizationUnitRepository { get; }
//     protected ISettingProvider SettingProvider { get; }
//     protected ICancellationTokenProvider CancellationTokenProvider { get; }
//     protected IDistributedEventBus DistributedEventBus { get; }
//     protected IIdentityLinkUserRepository IdentityLinkUserRepository { get; }
//     protected IDistributedCache<AbpDynamicClaimCacheItem> DynamicClaimCache { get; }
//     protected override CancellationToken CancellationToken => CancellationTokenProvider.Token;
//
//     public CustomIdentityUserManager(IdentityUserStore store,
//         IIdentityRoleRepository roleRepository,
//         IIdentityUserRepository userRepository,
//         IOptions<IdentityOptions> optionsAccessor,
//         IPasswordHasher<IdentityUser> passwordHasher,
//         IEnumerable<IUserValidator<IdentityUser>> userValidators,
//         IEnumerable<IPasswordValidator<IdentityUser>> passwordValidators,
//         ILookupNormalizer keyNormalizer,
//         IdentityErrorDescriber errors,
//         IServiceProvider services,
//         ILogger<IdentityUserManager> logger,
//         ICancellationTokenProvider cancellationTokenProvider,
//         IOrganizationUnitRepository organizationUnitRepository,
//         ISettingProvider settingProvider,
//         IDistributedEventBus distributedEventBus,
//         IIdentityLinkUserRepository identityLinkUserRepository,
//         IDistributedCache<AbpDynamicClaimCacheItem> dynamicClaimCache) :
//         base(store, roleRepository, userRepository, optionsAccessor, passwordHasher, userValidators, passwordValidators,
//             keyNormalizer, errors, services, logger, cancellationTokenProvider, organizationUnitRepository,
//             settingProvider, distributedEventBus, identityLinkUserRepository, dynamicClaimCache)
//     {
//     }
//
//     public virtual async Task<IdentityUser> GetByIdAsync(Guid id)
//     {
//         var user = await Store.FindByIdAsync(id.ToString(), CancellationToken);
//         if (user == null)
//         {
//             throw new EntityNotFoundException(typeof(IdentityUser), id);
//         }
//
//         return user;
//     }
// }