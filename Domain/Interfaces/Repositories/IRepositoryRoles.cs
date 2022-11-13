using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IRepositoryRoles : IRepository<Roles>
    {
        public void AssignDefaultRole(User user);
        public Rol Check(User user);
    }
}
