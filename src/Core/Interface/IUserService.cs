using DTO;
using DTO.CustomModel;
using Entity;
using Entity.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUserById(string Id);
       Task<User> GetUserByEmail(string email);
        void UpdareUser(User user);

    }
}
