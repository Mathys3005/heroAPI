using heroAPI.Models;
using heroAPI.Services.HeroPowerService;
using heroAPI.Services.HeroService;
using heroAPI.Services.PowerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace heroAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PowerController : ControllerBase
    {
        private readonly IPowerService _powerService;
        private readonly IHeroPowerService _heroPowerService;
        private readonly IHeroService _heroService;
        public PowerController(IPowerService powerService, IHeroPowerService heroPowerService, IHeroService heroService)
        {
            _powerService = powerService;
            _heroPowerService = heroPowerService;
            _heroService = heroService;
        }

        // GET: api/power
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Power>>> GetAllPowers()
        {
            var powers = await _powerService.GetAllPowersAsync();
            return Ok(powers);
        }

        // GET: api/power/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Power>> GetPowerById(int id)
        {
            var power = await _powerService.GetPowerByIdAsync(id);

            if (power == null)
            {
                return NotFound();
            }

            return Ok(power);
        }

        // POST: api/power
        [HttpPost]
        public async Task<ActionResult<Power>> CreatePower([FromBody] Power power)
        {
            var createdPower = await _powerService.AddPowerAsync(power);
            return CreatedAtAction(nameof(GetPowerById), new { id = createdPower.PowerId }, createdPower);
        }

        // PUT: api/power/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePower(int id, [FromBody] Power power)
        {
            if (id != power.PowerId)
            {
                return BadRequest();
            }

            try
            {
                await _powerService.UpdatePowerAsync(power);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _powerService.GetPowerByIdAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/power/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePower(int id)
        {
            var power = await _powerService.GetPowerByIdAsync(id);

            if (power == null)
            {
                return NotFound();
            }

            await _powerService.DeletePowerAsync(power);
            return NoContent();
        }

        [HttpPost("{powerId}/heroes")]
        public async Task<ActionResult<Power>> AddHeroesToPower(int powerId, List<int> heroIds)
        {
            var power = await _powerService.GetPowerByIdAsync(powerId);
            if (power == null)
            {
                return NotFound();
            }

            foreach (var heroId in heroIds)
            {
                var hero = await _heroService.GetHeroByIdAsync(heroId);
                if (hero == null)
                {
                    return NotFound($"Hero with id {heroId} not found");
                }

                var heroPower = new HeroPower
                {
                    HeroId = heroId,
                    PowerId = powerId
                };

                await _heroPowerService.AddHeroPowerAsync(heroPower);
            }

            return Ok(power);
        }

        [HttpGet("{powerId}/heroes")]
        public async Task<ActionResult<Power>> GetPowerWithHeroes(int powerId)
        {
            var power = await _powerService.GetPowerByIdWithHeroesAsync(powerId);
            if (power == null)
            {
                return NotFound();
            }

            return Ok(power);
        }
    }
}

