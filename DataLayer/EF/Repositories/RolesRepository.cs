using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Linq;

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

        public Rol Check(User user)
        {
            Roles relacion = _context.RolesDeUsuarios.FirstOrDefault(r => r.UserId == user.Id);
            Rol rol = _context.Roles.FirstOrDefault(r => r.Id == relacion.RolId);
            if (relacion == null)
            {
                throw new Exception("User has not a defined role.");
            }
            return rol;
        }

        public void Create(Roles o)
        {
            throw new NotImplementedException();
        }
    }
}
