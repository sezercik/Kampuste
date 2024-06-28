using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Kampus.PostReplies
{
    public interface IPostReplyAppService : IApplicationService
    {
        Task<PagedResultDto<PostReplyDto>> GetPostReplyList(GetPostReplyListDto input);
        Task<PostReplyDto> GetPostReplyById(Guid postReplyId);
        Task<PostReplyDto> CreatePostReply(CreatePostReplyDto input);
        Task<CustomResultDto> DeletePostReply(Guid postReplyId);
    }
}
