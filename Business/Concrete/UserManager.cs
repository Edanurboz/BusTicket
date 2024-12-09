using Business.Abstract;
using Business.DTO;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }


        public string CreateUser(CreateUserDTO user)
        {
            // Kullanıcı oluşturma işlemleri
            // Örneğin, validasyon yapabilirsiniz
           var newUser=new User();
            newUser.name = user.name;
            newUser.email = user.email;
            newUser.password = user.password;
            newUser.surname = user.surname;
            newUser.phone_number = user.phone_number;
            _userRepository.Create(newUser);

            return "Kişi başarıyla eklendi.";
        }

        public void DeleteUser(DeleteUserDTO user)
        {
            var newUser = new User();
            newUser.user_id = user.user_id;
        }

        public List<User> GetAllUsers()
        {

            return _userRepository.GetAllUsers();
        }

        public User GetUserByEmail(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new KeyNotFoundException("Bu e-posta adresine sahip kullanıcı bulunamadı.");
            }
            return user;
        }

        public object GetUserById(int id)
        {
            var user = _userRepository.Get(u => u.user_id == id);
            if (user == null)
            {
                throw new KeyNotFoundException("Bu kullanıcı bulunamadı.");
            }
            return user;
        }

        public void UpdateUser(UpdateUserDTO user)
        {
           
            var newUser = new User();
            newUser.name = user.name;
            newUser.email = user.email;
            newUser.password = user.password;
            newUser.surname = user.surname;
            newUser.phone_number = user.phone_number;
            _userRepository.Update(newUser);
        }
    }
}
