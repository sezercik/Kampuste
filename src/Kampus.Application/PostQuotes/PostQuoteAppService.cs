using Kampus.PostReplies;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace Kampus.PostQuotes
{
    public class PostQuoteAppService : ApplicationService, IPostQuoteAppService
    {
        private readonly IPostQuoteRepository _postQuoteRepository;
        private readonly PostQuoteManager _postQuoteManager;
        private readonly ICurrentUser _currentUser;

        public PostQuoteAppService(IPostQuoteRepository postQuoteRepository, PostQuoteManager postQuoteManager, ICurrentUser currentUser)
        {
            _postQuoteRepository = postQuoteRepository;
            _postQuoteManager = postQuoteManager;
            _currentUser = currentUser;
        }

        public async Task<PostQuoteDto> CreatePostQuote(CreatePostQuoteDto input)
        {
            //TODO: check for users role to make sure they are allowed to create a post
            if (_currentUser.IsAuthenticated)
            {
                Guid userId = _currentUser.Id ?? Guid.Empty;

                //User only can have one quote per post
                var existingQuote = await _postQuoteRepository.GetQuoteByUserAndPost(userId, input.QuotedPostId);
                if (existingQuote != null)
                {
                    throw new Exception("User already quoted this post!");
                }
                var newPost = await _postQuoteManager.CreateAsync(userId, input.QuotedPostId, input.Content, input.BlobNames);
                await _postQuoteRepository.InsertAsync(newPost);
                return ObjectMapper.Map<PostQuote, PostQuoteDto>(newPost);
            }
            return null;
        }

        public async Task<CustomResultDto> DeletePostQuote(Guid postQuoteId)
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

            var postReply = await _postQuoteRepository.GetByIdAsync(postQuoteId);
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

            await _postQuoteRepository.DeleteAsync(postReply);

            result.IsSuccess = true;
            result.ResultCode = 200;
            result.ResultMessage = "Başarıyla Silindi!";
            return result;
        }

        public async Task<PostQuoteDto> GetPostQuoteById(Guid postQuoteId)
        {
            var postQuote = await _postQuoteRepository.GetByIdAsync(postQuoteId);
            if (postQuote == null)
            {
                throw new Exception("PostReply not found!");
            }
            return ObjectMapper.Map<PostQuote, PostQuoteDto>(postQuote);
        }

        public async Task<PagedResultDto<PostQuoteDto>> GetPostQuoteList(GetPostQuoteListDto input)
        {
            input.Sorting ??= nameof(PostQuote.Content);
            var postQuotes = await _postQuoteRepository.GetAllQuotesOfPost(
                input.QuotedPostId,
                input.SkipCount, 
                input.MaxResultCount, 
                input.Sorting, 
                input.Filter);

            var totalCount = input.Filter == null
                ? await _postQuoteRepository.CountAsync()
                : await _postQuoteRepository.CountAsync(
                    pr => pr.Content.Contains(input.Filter)
                );

            return new PagedResultDto<PostQuoteDto>(
                totalCount,
                ObjectMapper.Map<List<PostQuote>, List<PostQuoteDto>>(postQuotes)
            );
        }

    }
}
