using System.ComponentModel.DataAnnotations;

namespace NZWalksAPIs.Model.DTO
{
    public class Registerrequestdto
    {
        [Required]
        [DataType(DataType.EmailAddress)]   
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public  string  password { get; set; }

        public string[] Roles { get; set; } 

    }
}
