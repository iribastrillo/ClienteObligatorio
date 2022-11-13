using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataLayer.EF.Repositories
{
    public class UserRepository : IRepositoryUser
    {
        private ClientContext _context;

        public UserRepository (ClientContext context)
        {
            _context = context;
        }
        public void Create(User o)
        {
            User user = _context.Users.FirstOrDefault(u => u.Email.Value == o.Email.Value);
            if (user != null)
            {
                throw new Exception("User already exists.");
            }
            _context.Users.Add(o);
            _context.SaveChanges();
        }
        public User Find(string username, string password)
        {
            IEnumerable<User> users = from u in _context.Users
                                      where u.Username.Value == username && u.Password.Value == password
                                      select u;
            User user = users.FirstOrDefault();
            return user;
        }
    }
}
