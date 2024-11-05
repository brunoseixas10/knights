using Knights.Model;
using Knights.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Knights.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public sealed class KnightsController : ControllerBase
    {
        private readonly IKnightsRepository repository;

        public KnightsController(IKnightsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> List([FromQuery] string? filter)
        {
            var response = await repository.List(filter == "heroes");
            if (response == null) 
                return NoContent();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] string id)
        {
            var response = await repository.GetById(id);
            if (response == null)
                return NoContent();

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Knight knight)
        {
            var response = await repository.Add(knight);
            if (response == null)
                return BadRequest();

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove([FromRoute] string id)
        {
            await repository.Remove(id);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update([FromRoute] string id, [FromBody] string nickname)
        {
            await repository.UpdateNickname(id, nickname);
            return Ok();
        }
    }
}
