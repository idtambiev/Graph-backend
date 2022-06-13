using Graph.API.Controllers.Base;
using Graph.Services.DTOs.Edge;
using Graph.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Graph.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EdgeController : BaseController
    {
        private readonly IEdgeService _service;

        public EdgeController(IEdgeService service)
        {
            _service = service;
        }


        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateVertex([FromBody]CreateEdgeDTO dto)
        {
            await _service.CreateEdge(dto);
            return Ok();
        }
    }
}
