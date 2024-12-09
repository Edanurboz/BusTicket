using Business.Abstract;
using Business.DTO;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] CreateUserDTO request)
        {
            string sonuc= _userService.CreateUser(request);
            return Ok(sonuc);
        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromBody] UpdateUserDTO request)
        {
            _userService.UpdateUser(request);
            return Ok();
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser([FromBody] DeleteUserDTO request)
        {
            _userService.DeleteUser(request);
            return Ok();
        }

        [HttpGet("byemail")]
        public IActionResult GetUserByEmail(string email)
        {
            var user = _userService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost("Login")]
        public IActionResult Login(string email, string password)
        {
            var user = _userService.Login(email,password);
            if (user == null)
            {
                return Ok("Kullanıcı adı veya şifre hatalı.");
            }
            return Ok("Kullanıcı girişi başarılı");
        }
    }
}
