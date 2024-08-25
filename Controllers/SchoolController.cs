using heroAPI.Models;
using heroAPI.Services.SchoolService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace heroAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        // GET: api/school
        [HttpGet]
        public async Task<ActionResult<IEnumerable<School>>> GetAllSchools()
        {
            var schools = await _schoolService.GetAllSchoolsAsync();
            return Ok(schools);
        }

        // GET: api/school/5
        [HttpGet("{id}")]
        public async Task<ActionResult<School>> GetSchoolById(int id)
        {
            var school = await _schoolService.GetSchoolByIdAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            return Ok(school);
        }

        // POST: api/school
        [HttpPost]
        public async Task<ActionResult<School>> CreateSchool([FromBody] School school)
        {
            var createdSchool = await _schoolService.AddSchoolAsync(school);
            return CreatedAtAction(nameof(GetSchoolById), new { id = createdSchool.SchoolId }, createdSchool);
        }

        // PUT: api/school/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchool(int id, [FromBody] School school)
        {
            if (id != school.SchoolId)
            {
                return BadRequest();
            }

            try
            {
                await _schoolService.UpdateSchoolAsync(school);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _schoolService.GetSchoolByIdAsync(id) == null)
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

        // DELETE: api/school/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            var school = await _schoolService.GetSchoolByIdAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            await _schoolService.DeleteSchoolAsync(school);
            return NoContent();
        }
    }
}
