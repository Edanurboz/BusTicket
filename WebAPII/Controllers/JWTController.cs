using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPII.Security;

namespace WebAPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public JWTController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Token token = MyTokenHandler.CreateToken(_configuration);
            return Ok(token);
        }
    }
}
