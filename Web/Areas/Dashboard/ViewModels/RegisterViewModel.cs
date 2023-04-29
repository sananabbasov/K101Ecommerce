using System.ComponentModel.DataAnnotations;

namespace Web.Areas.Dashboard.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MinLength(3,ErrorMessage ="Ad 3 simvoldan asagi ola bilmez."),MaxLength(25, ErrorMessage ="Ad 25 simvoldan uzun ola bilmez.")]
        public string Name { get; set; }
        [Required]
        [MinLength(3,ErrorMessage ="Soyad 3 simvoldan asagi ola bilmez."),MaxLength(25, ErrorMessage ="Soyad 25 simvoldan uzun ola bilmez.")]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string RepeatPassword { get; set; }
    }
}