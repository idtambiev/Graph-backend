using Graph.Common.Models;
using Graph.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Graph.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            var result = await _service.Login(model);
            return Ok(result);
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody]RegistrationModel model)
        {
            var result = await _service.Registration(model);
            return Ok(result);
        }

        [HttpGet("test")]
        [Authorize]
        public async Task<IActionResult> TestAuthorize()
        {
            return Ok();
        }


        public async Task<IActionResult> ForgotPassword()
        {
            return Ok();
        }

  
    }
}
