using Graph.API.Controllers.Base;
using Graph.Services.DTOs;
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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetGraph([FromQuery]int id)
        {
            var result = await _graphService.GetGraphById(id);

            return Ok(result);
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> CreateGraph([FromBody] CreateGraphDTO dto)
        {
            var userId = GetUserId();
            await _graphService.CreateGraph(userId, dto);
            return Ok();
        }

        [HttpPost("save")]
        [Authorize]
        public async Task<IActionResult> SaveGraph([FromBody]SaveGraphDTO dto)
        {
            var userId = GetUserId();
            await _graphService.SaveGraph(userId, dto);
            return Ok();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteGraph([FromQuery]int id)
        {
            await _graphService.DeleteGraph(id);
            return Ok();
        }
    }
}
