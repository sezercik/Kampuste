using System;
using Volo.Abp.Application.Dtos;

namespace Kampus.Posts;

public class PostDto : FullAuditedEntityDto<Guid>
{
    public virtual Guid UserId { get; protected set; }
    public string Content { get; set; }
    public string[]? BlobNames { get; set; }
}