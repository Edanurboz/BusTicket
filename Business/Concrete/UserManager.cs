using Business.Abstract;
using Business.DTO;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserRepository _userRepository;
        BiletOtomasyonu _context;

        public UserManager(IUserRepository userRepository,BiletOtomasyonu context)
        {
            _userRepository = userRepository;
            _context = context;

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
            newUser.identity_=user.identity_;
            newUser.gender = user.gender;
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

        public User Login(string email, string password)
        {
            var user =_userRepository.Get(u=>u.email== email & u.password==password);
            if (user == null)
            {
                return user; 
            }
            return user;
            
        }

        public void UpdateUser(UpdateUserDTO user)
        {
           
            var newUser = new User();
            newUser.user_id = user.user_id;
            newUser.name = user.name;
            newUser.email = user.email;
            newUser.password = user.password;
            newUser.surname = user.surname;
            newUser.phone_number = user.phone_number;
            newUser.identity_ = user.identity_;
            newUser.gender = user.gender;
            _userRepository.Update(newUser);
            
        }
    }
}
