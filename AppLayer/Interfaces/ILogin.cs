using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppLayer.Interfaces
{
    public interface ILogin
    {
        public User DoLogin(string email, string password);
    }
}
