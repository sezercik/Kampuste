using System;
using System.ComponentModel.DataAnnotations;

namespace Kampus.Posts;

public class CreatePostDto
{
    [Required]
    public virtual Guid UserId { get; protected set; }
    [Required]
    public string Content { get; set; }
    public string[]? BlobNames { get; set; }
}