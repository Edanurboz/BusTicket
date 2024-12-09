using Business.DTO;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        string CreateUser(CreateUserDTO user);
        void UpdateUser(UpdateUserDTO user);
        void DeleteUser(DeleteUserDTO user);
        User GetUserByEmail(string email);
        List<User> GetAllUsers();
        object GetUserById(int id);
    }
}
