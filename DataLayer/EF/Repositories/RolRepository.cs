using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer.EF.Repositories
{
    public class RolRepository : IRolRepository
    {
        ClientContext _context;

        public RolRepository (ClientContext context)
        {
            _context = context;
        }
        public IEnumerable<Rol> FindAll()
        {
            return (from roles in _context.Roles select roles).ToList();
        }

        public Rol FindByID()
        {
            throw new NotImplementedException();
        }
    }
}
