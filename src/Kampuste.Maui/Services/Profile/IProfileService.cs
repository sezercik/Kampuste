using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Account;
using Volo.Abp.Application.Dtos;
namespace Kampuste.Maui.Services.Profile
{
    public interface IProfileService
    {
        Task<List<ProfileDto>> PostProfileAsync(ProfileDto postReply);
        Task<List<ProfileDto>> GetProfileAsync();
        Task<List<ProfileDto>> PutProfileAsync(ProfileDto postReply);
    }
}
