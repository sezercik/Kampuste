
using Kampus.PostReplies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kampuste.Maui.Services.PostReply
{
    public interface IPostReplyService
    {
        Task<List<PostReplyDto>> PostPostReplyAsync(PostReplyDto postReply);
        Task<List<PostReplyDto>> DeletePostReplyAsync(Guid postRepliedId);
        Task<List<PostReplyDto>> GetPostreplyByIdAsync(Guid postRepliedId);
        Task<List<PostReplyDto>> GetPostReplyListAsync(Guid postRepliedId, string filter, string sorting, int skipCount, int maxResultCount);
    }
}
