using System.ComponentModel.DataAnnotations;

namespace Cliente.Models.VMs
{
    public class UserViewModel
    {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string Username { get; set; }
        [Display(Name = "Contraseña")]
        [Required]
        public string Password { get; set; }
        [Display(Name = "Correo electrónico")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
