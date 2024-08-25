using heroAPI.Models;
using heroAPI.Services.HeroPowerService;
using Microsoft.AspNetCore.Mvc;

namespace heroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroPowerController : ControllerBase
    {
        private readonly IHeroPowerService _heroPowerService;

        public HeroPowerController(IHeroPowerService heroPowerService)
        {
            _heroPowerService = heroPowerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeroPower>>> GetAllHeroPowers()
        {
            return Ok(await _heroPowerService.GetAllHeroPowersAsync());
        }

        [HttpPost]
        public async Task<ActionResult<HeroPower>> AddHeroPower(HeroPower heroPower)
        {
            var createdHeroPower = await _heroPowerService.AddHeroPowerAsync(heroPower);
            return CreatedAtAction(nameof(GetAllHeroPowers), new { heroId = createdHeroPower.HeroId, powerId = createdHeroPower.PowerId }, createdHeroPower);
        }

        [HttpDelete("{heroId}/{powerId}")]
        public async Task<ActionResult> DeleteHeroPower(int heroId, int powerId)
        {
            await _heroPowerService.DeleteHeroPowerAsync(heroId, powerId);
            return NoContent();
        }
    }
}
