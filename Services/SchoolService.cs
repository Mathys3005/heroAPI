using heroAPI.Data;
using heroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace heroAPI.Services
{
    public class SchoolService
    {
        private readonly DataContext _context;

        public SchoolService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<School>> GetAllSchoolsAsync()
        {
            return await _context.School.ToListAsync();
        }

        public async Task<School> GetSchoolByIdAsync(int id)
        {
            return await _context.School.FindAsync(id);
        }

        public async Task<School> AddSchoolAsync(School school)
        {
            _context.School.Add(school);
            await _context.SaveChangesAsync();
            return school;
        }

        public async Task<School> UpdateSchoolAsync(School school)
        {
            _context.Entry(school).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return school;
        }

        public async Task<School> DeleteSchoolAsync(School school)
        {
            _context.School.Remove(school);
            await _context.SaveChangesAsync();
            return school;
        }
    }
}
