using Kampus.PostReplies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Kampus.PostQuotes
{
    public class PostQuoteManager : DomainService
    {
        private readonly IPostQuoteRepository _postQuoteRepository;

        public PostQuoteManager(IPostQuoteRepository postQuoteRepository)
        {
            _postQuoteRepository = postQuoteRepository;
        }

        public async Task<PostQuote> CreateAsync(Guid userId, Guid repliedPostId, string content, string[]? blobNames)
        {
            return new PostQuote(
                userId, content, repliedPostId, blobNames
            );
        }
    }
}
