
using Kampus.PostReplies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Kampuste.Maui.Services.PostReply
{
    public interface IPostReplyService
    {
        Task<List<PostReplyDto>> PostPostReplyAsync(PostReplyDto postReply);
        Task<List<PostReplyDto>> DeletePostReplyAsync(Guid postRepliedId);
        Task<List<PostReplyDto>> GetPostReplyByIdAsync(Guid postRepliedId);
        Task<PagedResultDto<PostReplyDto>> GetPostReplyListAsync(Guid postRepliedId, string filter, string sorting, int skipCount, int maxResultCount);
    }
}
