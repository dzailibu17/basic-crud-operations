using Model.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Model.DTOs
{
    public class IdentityUserDTO
    {
        [Required]
        public UserDTO User { get; set; }
        [Required]
        [Password]
        public string Password { get; set; }
    }
}
