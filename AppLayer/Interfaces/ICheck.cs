using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppLayer.Interfaces
{
    public interface ICheck
    {
        public Rol Check(User user);
    }
}
