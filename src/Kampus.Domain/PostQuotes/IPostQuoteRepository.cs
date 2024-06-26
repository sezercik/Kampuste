﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Kampus.PostQuotes
{
    public interface IPostQuoteRepository : IRepository<PostQuote, Guid>
    {
        Task<PostQuote> GetByIdAsync(Guid quoteId);
        Task<List<PostQuote>> GetAllQuotesOfPost(
            Guid quotedPostId,
            int skipCount, 
            int maxResultCount, 
            string sorting, 
            string filter = null
            );
        Task<PostQuote> GetQuoteByUserAndPost(Guid userId, Guid quotedPostId);
    }
}
