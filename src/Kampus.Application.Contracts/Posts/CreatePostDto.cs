using System;
using System.ComponentModel.DataAnnotations;

namespace Kampus.Posts;

public class CreatePostDto
{
    [Required]
    public string Content { get; set; }
    public string[]? BlobNames { get; set; }
}