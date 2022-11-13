using AppLayer.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppLayer.UseCases
{
    public class UCAssignDefaultRole : IAssignDefault
    {
        private IRepositoryRoles _repository;

        public UCAssignDefaultRole (IRepositoryRoles repository)
        {
            _repository = repository;
        }
        public void AssignDefaultRole(User user)
        {
            _repository.AssignDefaultRole(user);
        }
    }
}
