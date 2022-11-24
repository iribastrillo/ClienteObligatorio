using AppLayer.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;

namespace AppLayer.UseCases
{
    public class UCLogin : ILogin
    {
        private IRepositoryUser _repository;

        public UCLogin (IRepositoryUser repository)
        {
            _repository = repository;
        }
        public User DoLogin(string email, string password)
        {
            User found = _repository.Find(email, password);
            if (found == null)
            {
                throw new Exception("Invalid login credentials.");
            }
            return found;
        }
    }
}
