using Domain.Entities;
using System.Collections.Generic;

namespace AppLayer.Interfaces
{
    public interface IListAll
    {
        public IEnumerable<Rol> FindAll();
    }
}
