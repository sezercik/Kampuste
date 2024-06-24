using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Kampus.UserSettings;

public interface IUserSettingRepository : IRepository<UserSetting, Guid>
{
    Task<UserSetting> FindByUserId(Guid userId);
}