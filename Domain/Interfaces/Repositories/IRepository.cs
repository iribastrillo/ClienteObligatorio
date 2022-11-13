using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        public T Find(string username, string password);
        public void Create(T o);
    }
}
