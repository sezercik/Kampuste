using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Kampus.UserFriends
{
    public class GetUserFriendListDto : PagedAndSortedResultRequestDto
    {
        public Guid UserId { get; set; }
        public string? Filter { get; set; }
    }
}
