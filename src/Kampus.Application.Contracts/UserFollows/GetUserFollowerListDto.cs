﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Kampus.UserFollows
{
    public class GetUserFollowerListDto : PagedAndSortedResultRequestDto
    {
        public Guid UserId { get; set; }
        public string? Filter { get; set; }
    }
}
