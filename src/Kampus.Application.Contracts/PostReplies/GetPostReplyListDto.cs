using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Kampus.PostReplies
{
    public class GetPostReplyListDto : PagedAndSortedResultRequestDto
    {
        [Required]
        public Guid RepliedPostId { get; set; }
        public string? Filter { get; set; }
    }
}
