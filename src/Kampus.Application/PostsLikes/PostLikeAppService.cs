using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace Kampus.PostsLikes
{
    public class PostLikeAppService : ApplicationService, IPostLikeAppService
    {
        private readonly IPostLikeRepository _postLikeRepository;
        private readonly PostLikeManager _postLikeManager;
        private readonly ICurrentUser _currentUser;
        public PostLikeAppService(
            IPostLikeRepository postLikeRepository, 
            ICurrentUser currentUser,
            PostLikeManager postLikeManager
            )
        {
            _postLikeRepository = postLikeRepository;
            _currentUser = currentUser;
            _postLikeManager = postLikeManager;
        }
       
        [Authorize]
        public async Task<bool> CreatePostLike(CreatePostLikeDto input)
        {
            if (_currentUser.IsAuthenticated)
            {
                Guid userId = _currentUser.Id ?? Guid.Empty;
                var existingLike = await _postLikeRepository.FirstOrDefaultAsync(pl => pl.PostId == input.PostId && pl.UserId == userId);
                if (existingLike != null)
                {
                    return false;
                }
                //TODO: Make this more universal if like exist then remove like or add like
                var newPostLike = await _postLikeManager.CreateAsync(userId,input.PostId);
                await _postLikeRepository.InsertAsync(newPostLike);
                return true;
            }
            return false;
        }

        [Authorize]
        public async Task<bool> RemovePostLike(RemovePostLikeDto input)
        {
            if (_currentUser.IsAuthenticated)
            {
                Guid userId = _currentUser.Id ?? Guid.Empty;
                var existingLike = await _postLikeRepository.FirstOrDefaultAsync(pl => pl.PostId == input.PostId && pl.UserId == userId);
                if (existingLike == null)
                {
                    return false;
                }
                await _postLikeRepository.DeleteAsync(existingLike);
                return true;
            }
            return false;
        }
        public async Task<int> GetPostLikeCountByPostId(GetPostLikeListDtoByPostId input)
        {
            var likeCount = await _postLikeRepository.GetLikeCountByPostIdAsync(input.PostId);
            return likeCount;
        }

        public async Task<int> GetPostLikeCountByUserId(GetPostLikeListDtoByUserId input)
        {
            var likeCount = await _postLikeRepository.GetLikeCountByUserIdAsync(input.UserId);
            return likeCount;
        }

        public async Task<List<PostLikeDto>> GetPostLikeListByPostId(GetPostLikeListDtoByPostId input)
        {
            var posts = await _postLikeRepository.GetByPostIdAsync(input.PostId);
            return ObjectMapper.Map<List<PostLike>, List<PostLikeDto>>(posts);
        }

        public async Task<List<PostLikeDto>> GetPostLikeListByUserId(GetPostLikeListDtoByUserId input)
        {
            var posts = await _postLikeRepository.GetByUserIdAsync(input.UserId);
            return ObjectMapper.Map<List<PostLike>, List<PostLikeDto>>(posts);
        }
    }
}
