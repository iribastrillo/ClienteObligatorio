using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Roles
    {
        public int RolId { get; set; }
        public int UserId { get; set; }
        public Rol Rol { get; set; }
        public User User { get; set; }
    }
}
