using System.ComponentModel.DataAnnotations;

namespace EmailSender.Core.Models
{
    public class Email
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Subject is required"), MaxLength(150)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }


    }
}
