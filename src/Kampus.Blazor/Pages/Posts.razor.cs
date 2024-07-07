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

    private Guid EditingPostId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await GetPostsAsync();
    }
    private async Task GetPostsAsync()
    {
        var result = await PostAppService.GetListPosts(
            new GetPostListDto()
            {
                MaxResultCount = PageSize,
                SkipCount = CurrentPage * PageSize,
                Sorting = CurrentSorting
            }
        );

        PostList = result.Items;
        TotalCount = (int)result.TotalCount;
    }

    private async Task OnDataGridReadAsync(DataGridReadDataEventArgs<PostDto> e)
    {
        CurrentSorting = e.Columns
            .Where(c => c.SortDirection != SortDirection.Default)
            .Select(c => c.Field + (c.SortDirection == SortDirection.Descending ? " DESC" : ""))
            .JoinAsString(",");
        CurrentPage = e.Page - 1;

        await GetPostsAsync();

        await InvokeAsync(StateHasChanged);
    }

    private async Task DeletePostAsync(PostDto post)
    {
        var confirmMessage = L["PostDeletionConfirmationMessage", post.Id];
        if (!await Message.Confirm(confirmMessage))
        {
            return;
        }

        await PostAppService.DeleteAsync(post.Id);
        await GetPostsAsync();
    }
}
