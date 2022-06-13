using Graph.API.Controllers.Base;
using Graph.Services.DTOs.Vertex;
using Graph.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Graph.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VertexController : BaseController
    {
        private readonly IVertexService _service;

        public VertexController(IVertexService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateVertex([FromBody]CreateVertexDTO dto)
        {
            await _service.CreateVertex(dto);
            return Ok();
        }

        [HttpPost("save-coordinates")]
        [Authorize]
        public async Task<IActionResult> SaveCoordinates([FromBody] CoordinatesDTO dto)
        {
            await _service.SaveCoordinates(dto);
            return Ok();
        }

        [HttpGet("get-coordinates")]
        [Authorize]
        public async Task<IActionResult> GetCoordinates([FromQuery]int graphId)
        {
            var result = await _service.GetCoordinatesByGraphId(graphId);
            return Ok(result);
        }
    }
}
