using heroAPI.Models;
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
        public PowerController(IPowerService powerService)
        {
            _powerService = powerService;
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

    }
}

