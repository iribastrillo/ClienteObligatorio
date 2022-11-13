using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        public void Create(T o);
    }
}
