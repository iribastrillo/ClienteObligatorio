using AppLayer.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Entities;
using System.Collections.Generic;

namespace AppLayer.UseCases
{
    public class UCListRol : IListAll
    {
        IRolRepository _repository;
        public UCListRol (IRolRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Rol> FindAll()
        {
            return _repository.FindAll();
        }
    }
}
