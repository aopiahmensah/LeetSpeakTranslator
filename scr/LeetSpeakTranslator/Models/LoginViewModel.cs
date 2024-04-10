using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LeetSpeakTranslator.Models
{
    public class LoginViewModel
    {
        [Required]
        [RegularExpression(pattern: "^[^+%'-]+$", ErrorMessage = "Invalid Username")]
        [DisplayName("Username")]
        public string? Username { get; set; }

        [Required]
        [RegularExpression(pattern: "^[^+%'-]+$", ErrorMessage = "Invalid Password")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
