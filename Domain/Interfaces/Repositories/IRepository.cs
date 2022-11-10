using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        public T Find(T o);
        public void Create(T o);
    }
}
