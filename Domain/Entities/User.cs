using Domain.Interfaces;
using Domain.VO;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User : IEntity
    {
        public UsernameValue Username { get; set; }
        public PasswordValue Password { get; set; }
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
