using Graph.API.Controllers.Base;
using Graph.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Graph.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GraphController : BaseController
    {
        private readonly IGraphService _graphService;
        public GraphController(IGraphService graphService)
        {
            _graphService = graphService;
        }

        [HttpGet("list")]
        [Authorize]
        public async Task<IActionResult> GetGraphsList()
        {
            var userId = GetUserId();
            var result = await _graphService.GetGraphsList(userId);

            return Ok(result);
        }
    }
}
