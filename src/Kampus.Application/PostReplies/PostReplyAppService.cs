using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
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

        public async  Task<CustomResultDto> DeletePostReply(Guid postReplyId)
        {
            var result = new CustomResultDto
            {
                IsSuccess = false,
                ResultCode = 300,
                ResultMessage = "Bilinmeyen Hata!"
            };

            if (!_currentUser.IsAuthenticated)
            {
                result.ResultMessage = "User must be authenticated to delete a post reply.";
                return result;
            }

            var postReply = await _postReplyRepository.GetByIdAsync(postReplyId);
            if (postReply == null)
            {
                result.ResultMessage = "PostReply bulunamadı!";
                return result;
            }

            var isAdmin = _currentUser.Roles.Any(role => role == "admin");

            if (_currentUser.Id != postReply.UserId && !isAdmin)
            {
                result.ResultMessage = "Yetkisiz kişi!";
                return result;
            }

            await _postReplyRepository.DeleteAsync(postReply);

            result.IsSuccess = true;
            result.ResultCode = 200;
            result.ResultMessage = "Başarıyla Silindi!";
            return result;
        }

        public async Task<PostReplyDto> GetPostReplyById(Guid postReplyId)
        {
            var postReply = await _postReplyRepository.GetByIdAsync(postReplyId);
            if (postReply == null)
            {
                throw new UserFriendlyException("PostReply not found!", "502");
            }
            return ObjectMapper.Map<PostReply, PostReplyDto>(postReply);
        }

        public async Task<PagedResultDto<PostReplyDto>> GetPostReplyList(GetPostReplyListDto input)
        {
            input.Sorting ??= nameof(PostReply.Content);

            var postReplies = await _postReplyRepository.GetAllReplyOfPost(
                input.RepliedPostId,
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _postReplyRepository.CountAsync(p => p.RepliedPostId == input.RepliedPostId)
                : await _postReplyRepository.CountAsync(
                    pr => pr.Content.Contains(input.Filter) && pr.RepliedPostId == input.RepliedPostId
                );

            return new PagedResultDto<PostReplyDto>(
                totalCount,
                ObjectMapper.Map<List<PostReply>, List<PostReplyDto>>(postReplies)
            );
        }
    }
}
