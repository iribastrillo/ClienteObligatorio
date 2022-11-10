using AppLayer.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppLayer.UseCases
{
    public class UCLogin : ILogin
    {
        private IRepositoryUser _repository;

        public UCLogin (IRepositoryUser repository)
        {
            _repository = repository;
        }
        public void DoLogin(User user)
        {
            User found = _repository.Find(user);
            if (found == null)
            {
                throw new Exception("Invalid login credentials.");
            }
        }
    }
}
