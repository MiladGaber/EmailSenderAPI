using System.ComponentModel.DataAnnotations;

namespace EmailSender.Core.Models.ViewModels
{
    public class CreateEmailVM
    {
        [Required(ErrorMessage = "Subject is required"), MaxLength(150)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }
    }
}
