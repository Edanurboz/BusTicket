using Business.Abstract;
using Business.DTO;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPII.Security;

namespace WebAPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        IConfiguration _configuration;

        public UsersController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
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
            Token token = MyTokenHandler.CreateToken(_configuration);
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
                return Unauthorized("Kullanıcı adı veya şifre hatalı.");
            }
            Token token = MyTokenHandler.CreateToken(_configuration);
            return Ok(new { AccessToken = token.AccessToken, RefreshToken = token.RefreshToken,user });

        }
    }
}
