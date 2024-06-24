using System;
using Volo.Abp.Application.Dtos;

namespace Kampus.Posts;

public class GetPostListDtoByUserId : PagedAndSortedResultRequestDto
{
    public Guid userId { get; set; }
    public string? Filter { get; set; }
}