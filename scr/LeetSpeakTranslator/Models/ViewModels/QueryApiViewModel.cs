using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LeetSpeakTranslator.Models.ViewModels
{
    public class QueryApiViewModel
    {
        [Required(ErrorMessage = "Input String is required")]
        [DisplayName("Input String")]
        public string? Text { get; set; }
    }
}
