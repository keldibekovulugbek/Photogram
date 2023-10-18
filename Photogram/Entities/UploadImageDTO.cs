using System.ComponentModel.DataAnnotations;

namespace Photogram.Entities
{
    public class UploadImageDTO
    {
        [Required]
        public IFormFile Image { get; set; }
    }
}
