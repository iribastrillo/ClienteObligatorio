using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IRolRepository
    {
        public IEnumerable<Rol> FindAll();
        public Rol FindByID();
    }
}
