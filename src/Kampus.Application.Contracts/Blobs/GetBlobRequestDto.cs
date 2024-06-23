using System.ComponentModel.DataAnnotations;

namespace Kampus.Blobs;

public class GetBlobRequestDto
{
    [Required]
    public string Name{get;set;}
}