using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IRepositoryUser : IRepository<User>
    {
        public User Find(string email, string password);
    }
}
