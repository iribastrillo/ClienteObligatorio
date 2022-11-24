using Cliente.Models.VMs;
using Domain.Entities;
using Domain.VO;

namespace Cliente.Mapper
{
    public static class UserMapper
    {
        public static User ToUser (UserViewModel userVM)
        {
            if (userVM == null)
            {
                return null;
            }

            return new User(userVM.Username, userVM.Password, userVM.Email);
        }
    }
}
