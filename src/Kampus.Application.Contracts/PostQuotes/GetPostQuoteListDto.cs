using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Kampus.PostQuotes
{
    public class GetPostQuoteListDto : PagedAndSortedResultRequestDto
    {
        [Required]
        public Guid QuotedPostId { get; set; }
        public string? Filter { get; set; }
    }
}
