using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Kampus.PostQuotes
{
    public interface IPostQuoteAppService : IApplicationService
    {
        Task<PagedResultDto<PostQuoteDto>> GetPostQuoteList(GetPostQuoteListDto input);
        Task<PostQuoteDto> GetPostQuoteById(Guid postQuoteId);
        Task<PostQuoteDto> CreatePostQuote(CreatePostQuoteDto input);
        Task<CustomResultDto> DeletePostQuote(Guid postQuoteId);
    }
}
