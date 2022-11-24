using AppLayer.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace AppLayer.UseCases
{
    public class UCCheck : ICheck
    {
        private IRepositoryRoles _repository;
        public UCCheck (IRepositoryRoles repository)
        {
            _repository = repository;
        }

        public Rol Check(int role, User user)
        {
            return _repository.Check(role, user);
        }
    }
}
