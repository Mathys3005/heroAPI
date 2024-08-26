using heroAPI.Models;
using Microsoft.EntityFrameworkCore;
using heroAPI.Data;

namespace heroAPI.Services.PowerService
{
    public class PowerService : IPowerService
    {

        private readonly DataContext _context;

        public PowerService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Power>> GetAllPowersAsync()
        {
            return await _context.Power.ToListAsync();
        }

        public async Task<Power> GetPowerByIdAsync(int id)
        {
            return await _context.Power.FindAsync(id);
        }

        public async Task<Power> AddPowerAsync(Power power)
        {
            _context.Power.Add(power);
            await _context.SaveChangesAsync();
            return power;
        }

        public async Task<Power> UpdatePowerAsync(Power power)
        {
            _context.Entry(power).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return power;
        }

        public async Task<Power> DeletePowerAsync(Power power)
        {
            _context.Power.Remove(power);
            await _context.SaveChangesAsync();
            return power;
        }
    }
}
