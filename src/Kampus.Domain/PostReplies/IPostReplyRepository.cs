using Kampus.PostQuotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Kampus.PostReplies
{
    public interface IPostReplyRepository : IRepository<PostReply, Guid>
    {
        Task<PostReply> GetByIdAsync(Guid replyId);
        Task<List<PostReply>> GetAllReplyOfPost(
            Guid repliedPostId,
            int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null
            );
    }
}
