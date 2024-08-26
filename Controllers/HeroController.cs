using Microsoft.AspNetCore.Mvc;
using heroAPI.Models;
using heroAPI.Services.HeroService;
using heroAPI.Services.PowerService;

namespace heroAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroController : ControllerBase
    {
        private readonly IHeroService _heroService;


        public HeroController(IHeroService heroService)
        {
            _heroService = heroService;
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
    }
}
