using System.ComponentModel.DataAnnotations;

namespace NZWalksAPIs.Model.DTO
{
    public class ImageUploadRequestDto
    {
        [Required]
        public IFormFile file { get; set; }
        [Required]
        public string  FileName { get; set; }

        public string?  FileDescription { get; set; }


    }
}
