using System.ComponentModel.DataAnnotations;

namespace NZWalksAPIs.Model.DTO
{
    public class LoginRequestdto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string  Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
