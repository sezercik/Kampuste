using System;
using Volo.Abp.Application.Dtos;

namespace Kampus.Posts;

public class PostDto : FullAuditedEntityDto<Guid>
{
    public Guid UserId { get; set; }
    public string Content { get; set; }
    public string UserName { get; set; }
    public string[]? BlobNames { get; set; }
}