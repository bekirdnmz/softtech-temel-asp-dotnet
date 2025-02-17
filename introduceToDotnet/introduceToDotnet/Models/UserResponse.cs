using System.ComponentModel.DataAnnotations;

namespace introduceToDotnet.Models
{
    public class UserResponse
    {
        [Required(ErrorMessage = "Lütfen adınızı griniz")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyadı alanı boş olamaz")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Eposta formatı hatalı!")]
        [Required(ErrorMessage = "E-posta adresi boş olamaz")]
        public string Email { get; set; }

        public bool IsApproved { get; set; }





    }
}
