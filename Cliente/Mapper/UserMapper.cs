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

            return new User
            {
                Username = new UsernameValue (userVM.Username),
                Password = new PasswordValue (userVM.Password),
                Email = new EmailValue (userVM.Email)
            };
        }
    }
}
