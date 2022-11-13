using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;

namespace DataLayer.EF.Repositories
{
    public class RolesRepository : IRepositoryRoles
    {
        private ClientContext _context;

        public RolesRepository(ClientContext context)
        {
            _context = context;
        }

        public void AssignDefaultRole(User user)
        {
            // Falta implementar: corroborar que el usuario no tiene ese rol ya asignado (no debería).
            Roles rolDeUsuario = new Roles(3, user.Id);
            _context.RolesDeUsuarios.Add(rolDeUsuario);
            _context.SaveChanges();
        }

        public void Create(Roles o)
        {
            throw new NotImplementedException();
        }
    }
}
