using System.ComponentModel.DataAnnotations;

namespace Kampus.Blobs;

public class SaveBlobInputDto
{
    public byte[] Content { get; set; }
    [Required]
    public string Name { get; set; }
}