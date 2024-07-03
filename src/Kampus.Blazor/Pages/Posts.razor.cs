namespace Kampus.Blazor.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.DataGrid;
using Kampus.Posts;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
public partial class Posts
{
    private IReadOnlyList<PostDto> PostList { get; set; }
    private int PageSize { get; } = LimitedResultRequestDto.DefaultMaxResultCount;
    private int CurrentPage { get; set; }
    private string CurrentSorting { get; set; }
    private int TotalCount { get; set; }

    private CreatePostDto CreatePostDto { get; set; }
    private Guid EditingAuthorId { get; set; }

}
