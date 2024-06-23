using System.Threading.Tasks;
using Kampus.Blobs;
using Kampus.PostsFiles;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;

namespace Kampus.FileApp;

public class PostsFilesAppService(IBlobContainer<PostsFilesContainer> fileContainer)
    : ApplicationService, IFileAppService
{
    public async Task SaveBlobAsync(SaveBlobInputDto input)
    {
        await fileContainer.SaveAsync(input.Name, input.Content);
    }

    public async Task<BlobDto> GetBlobAsync(GetBlobRequestDto input)
    {
        var blob = await fileContainer.GetAllBytesAsync(input.Name);
        return new BlobDto{
            Name = input.Name,
            Content = blob
        };
    }
}