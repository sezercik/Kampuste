using System;
using System.Threading.Tasks;
using Kampus.EntityFrameworkCore;
using Kampus.UserSettings;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Kampus.Migrations.UserSettings;

public class EfCoreUserSettingRepository : EfCoreRepository<KampusDbContext, Kampus.UserSettings.UserSetting, Guid>,
    IUserSettingRepository
{
    public EfCoreUserSettingRepository(
        IDbContextProvider<KampusDbContext> dbContextProvider
        ):base(dbContextProvider)
    {
    }

    public async Task<Kampus.UserSettings.UserSetting> FindByUserId(Guid userId)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(usersettings => usersettings.UserId == userId);

    }
   
}