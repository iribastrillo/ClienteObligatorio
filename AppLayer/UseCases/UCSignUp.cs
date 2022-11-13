using AppLayer.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppLayer.UseCases
{
    public class UCSignUp : ISignUp
    {
        private IRepositoryUser _repository;

        public UCSignUp (IRepositoryUser repository)
        {
            _repository = repository;
        }
        public void SignUp(User user)
        {
            try
            {
                _repository.Create(user);
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
