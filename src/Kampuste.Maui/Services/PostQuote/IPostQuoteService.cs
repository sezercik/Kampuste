using Kampus.PostQuotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kampuste.Maui.Services.PostQuote
{
    public interface IPostQuoteService
    {
        Task<List<PostQuoteDto>> PostPostQuoteAsync();
        Task<List<PostQuoteDto>> DeletePostQuoteAsync();
        Task<List<PostQuoteDto>> GetPostQuoteByIdAsync();
        Task<List<PostQuoteDto>> GetPostQuoteListAsync();
    }
}
