using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
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
            //if (Check(user) != null)
            //{
            //    throw new Exception("User already contains the rol.");
            //}
            Roles rolDeUsuario = new Roles(3, user.Id);
            _context.RolesDeUsuarios.Add(rolDeUsuario);
            _context.SaveChanges();
        }

        public Rol Check(int role, User user)
        {
            Roles relacion = (from relation in _context.RolesDeUsuarios
                              where relation.UserId == user.Id && relation.RolId == role
                              select relation).FirstOrDefault();
            Rol rol = (from r in _context.Roles
                       where r.Id == relacion.RolId
                       select r).FirstOrDefault();

            if (relacion == null)
            {
                throw new Exception("Invalid role selected.");
            }
            return rol;
        }

        public void Create(Roles o)
        {
            throw new NotImplementedException();
        }
    }
}
