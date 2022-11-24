using Domain.Interfaces;
using Domain.VO;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User : IEntity
    {
        [Display(Name = "Nombre de usuario")]
        public UsernameValue Username { get; set; }
        [Display(Name = "Contraseña")]
        public PasswordValue Password { get; set; }
        [Display(Name = "Correo electrónico")]
        [EmailAddress]
        public EmailValue Email { get; set; }
        public int Id { get; set; }
        public User()
        {

        }
        public User (string username, string password)
        {
            Username = new UsernameValue (username);
            Password = new PasswordValue  (password);
        }

        public User (string username, string password, string email)
        {
            Username = new UsernameValue(username);
            Password = new PasswordValue(password);
            Email = new EmailValue(email);
        }
    }
}
