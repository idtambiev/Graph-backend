using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Graph.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController()
        {

        }

        public async Task<IActionResult> Login()
        {
            return Ok();
        }

        public async Task<IActionResult> Registration()
        {
            return Ok();
        }

        public async Task<IActionResult> ForgotPassword()
        {
            return Ok();
        }

  
    }
}
