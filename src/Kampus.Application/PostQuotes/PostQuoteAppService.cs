﻿using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
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
                    throw new UserFriendlyException("User already quoted this post","501");
                }
                var newPost = await _postQuoteManager.CreateAsync(userId, input.QuotedPostId, input.Content, input.BlobNames);
                await _postQuoteRepository.InsertAsync(newPost);
                return ObjectMapper.Map<PostQuote, PostQuoteDto>(newPost);
            }
            return null;
        }

        [Authorize]
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

            var postQuote = await _postQuoteRepository.GetByIdAsync(postQuoteId);
            if (postQuote == null)
            {
                result.ResultMessage = "PostQuote bulunamadı!";
                return result;
            }

            var isAdmin = _currentUser.Roles.Any(role => role == "admin");

            if (_currentUser.Id != postQuote.UserId && !isAdmin)
            {
                result.ResultMessage = "Yetkisiz kişi!";
                return result;
            }

            await _postQuoteRepository.DeleteAsync(postQuote);

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
                throw new UserFriendlyException("PostQuote not found!", "502");
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
                ? await _postQuoteRepository.CountAsync(p=>p.QuotedPostId == input.QuotedPostId)
                : await _postQuoteRepository.CountAsync(
                    pr => pr.Content.Contains(input.Filter) && pr.QuotedPostId == input.QuotedPostId
                );

            return new PagedResultDto<PostQuoteDto>(
                totalCount,
                ObjectMapper.Map<List<PostQuote>, List<PostQuoteDto>>(postQuotes)
            );
        }

    }
}
