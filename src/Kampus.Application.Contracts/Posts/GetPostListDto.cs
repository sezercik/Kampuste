using Volo.Abp.Application.Dtos;

namespace Kampus.Posts;

public class GetPostListDto : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }
}