using Kampus.PostQuotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Kampuste.Maui.Services.PostQuote
{
    public interface IPostQuoteService
    {
        Task<List<PostQuoteDto>> PostPostQuoteAsync(PostQuoteDto postQuote);
        Task<List<PostQuoteDto>> DeletePostQuoteAsync(Guid postQuoteId);
        Task<List<PostQuoteDto>> GetPostQuoteByIdAsync(Guid postQuoteId);
        Task<PagedResultDto<PostQuoteDto>> GetPostQuoteListAsync(Guid postQuoteId, string filter, string sorting, int skipCount, int maxResultCount);
    }
}
