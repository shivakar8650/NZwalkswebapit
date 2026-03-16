using System.ComponentModel.DataAnnotations;

namespace NZWalksAPIs.Model.DTO
{
    public class Updateegiondto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be a minimum of 3 characters")]
        [MaxLength(3, ErrorMessage = "Code has to be maximum of 3 character")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a maximum of 100 character")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }

    }
}
