using System.ComponentModel.DataAnnotations;

namespace SimpleEshop.API.MVCTemplate.Models
{
    public class UserLoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string? ReturnUrl { get; set; }

    }
}
