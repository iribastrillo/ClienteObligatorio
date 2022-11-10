using Domain.Interfaces;
using Domain.VO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User : IEntity
    {
        public UsernameValue Username { get; set; }
        public PasswordValue Password { get; set; }
        public int Id { get; set; }
        public User()
        {

        }
        public User (UsernameValue username, PasswordValue password)
        {
            Username = username;
            Password = password;
        }
    }
}
