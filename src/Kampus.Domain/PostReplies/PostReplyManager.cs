using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Kampus.PostReplies
{
    public class PostReplyManager : DomainService
    {
        private readonly IPostReplyRepository _postReplyRepository;

        public PostReplyManager(IPostReplyRepository postReplyRepository)
        {
            _postReplyRepository = postReplyRepository;
        }

        public async Task<PostReply> CreateAsync(Guid userId, Guid repliedPostId,string content, string[]? blobNames)
        {
            return new PostReply(
                userId,content,repliedPostId,blobNames
            );
        }
    }
}
