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
            throw new NotImplementedException();
        }
        public User Find(string username, string password)
        {
            User user = _context.Users.FirstOrDefault(u => username == u.Username.Value && password == u.Password.Value);          
            return user;
        }
    }
}
