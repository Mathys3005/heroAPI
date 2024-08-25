using Microsoft.AspNetCore.Mvc;
using heroAPI.Models;
using heroAPI.Services.HeroService;
using heroAPI.Services.PowerService;
using heroAPI.Services.HeroPowerService;

namespace heroAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroController : ControllerBase
    {
        private readonly IHeroService _heroService;

        private readonly IPowerService _powerService;
        private readonly IHeroPowerService _heroPowerService;

        public HeroController(IHeroService heroService, IPowerService powerService, IHeroPowerService heroPowerService)
        {
            _heroService = heroService;
            _powerService = powerService;
            _heroPowerService = heroPowerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hero>>> GetAllHeroes()
        {
            var heroes = await _heroService.GetAllHeroesAsync();
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHeroById(int id)
        {
            var hero = await _heroService.GetHeroByIdAsync(id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<Hero>> AddHero(Hero hero)
        {
            var createdHero = await _heroService.AddHeroAsync(hero);
            return CreatedAtAction(nameof(GetHeroById), new { id = createdHero.HeroId }, createdHero);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHero(int id, Hero hero)
        {
            if (id != hero.HeroId)
            {
                return BadRequest();
            }

            await _heroService.UpdateHeroAsync(hero);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var hero = await _heroService.GetHeroByIdAsync(id);
            if (hero == null)
            {
                return NotFound();
            }

            await _heroService.DeleteHeroAsync(hero);
            return NoContent();
        }

        
        [HttpPost("{heroId}/powers")]
        public async Task<ActionResult<Hero>> AddPowersToHero(int heroId, List<int> powerIds)
        {
            var hero = await _heroService.GetHeroByIdAsync(heroId);
            if (hero == null)
            {
                return NotFound();
            }

            foreach (var powerId in powerIds)
            {
                var power = await _powerService.GetPowerByIdAsync(powerId);
                if (power == null)
                {
                    return NotFound($"Power with id {powerId} not found");
                }

                var heroPower = new HeroPower
                {
                    HeroId = heroId,
                    PowerId = powerId
                };

                await _heroPowerService.AddHeroPowerAsync(heroPower);
            }

            return Ok(hero);
        }

        [HttpGet("{heroId}/powers")]
        public async Task<ActionResult<Hero>> GetHeroWithPowers(int heroId)
        {
            var hero = await _heroService.GetHeroByIdWithPowersAsync(heroId);
            if (hero == null)
            {
                return NotFound();
            }

            return Ok(hero);
        }
    }
}
