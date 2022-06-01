using Graph.API.Controllers.Base;
using Graph.Services.DTOs.Vector;
using Graph.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Graph.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VectorController : BaseController
    {
        private readonly IVectorService _service;
        public VectorController(IVectorService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateVector([FromBody] CreateVectorDTO dto)
        {
            await _service.CreateVector(dto);
            return Ok();
        }

        [HttpGet("by-id")]
        [Authorize]
        public async Task<IActionResult> GetVectorById([FromQuery] int graphId)
        {

            var result = await _service.GetVectorsListById(graphId);
            return Ok(result);
        }
    }
}
