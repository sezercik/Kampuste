using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Users;

namespace Kampus.PostReplies
{
    public class PostReplyAppService : ApplicationService, IPostReplyAppService
    {
        private readonly IPostReplyRepository _postReplyRepository;
        private readonly PostReplyManager _postReplyManager;
        private readonly ICurrentUser _currentUser;

        public PostReplyAppService(IPostReplyRepository postReplyRepository, PostReplyManager postReplyManager, ICurrentUser currentUser)
        {
            _postReplyRepository = postReplyRepository;
            _postReplyManager = postReplyManager;
            _currentUser = currentUser;
        }

        [Authorize]
        public async Task<PostReplyDto> CreatePostReply(CreatePostReplyDto input)
        {
            //TODO: check for users role to make sure they are allowed to create a post
            if (_currentUser.IsAuthenticated)
            {
                Guid userId = _currentUser.Id ?? Guid.Empty;
                var newPost = await _postReplyManager.CreateAsync(userId, input.RepliedPostId,input.Content, input.BlobNames);
                await _postReplyRepository.InsertAsync(newPost);
                return ObjectMapper.Map<PostReply, PostReplyDto>(newPost);
            }
            return null;
        }

        public Task<PostReplyDto> GetPostReplyById(Guid postReplyId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<PostReplyDto>> GetPostReplyList(GetPostReplyListDto input)
        {
            throw new NotImplementedException();
        }
    }
}
