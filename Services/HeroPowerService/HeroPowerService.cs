using heroAPI.Data;
using heroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace heroAPI.Services.HeroPowerService
{
    public class HeroPowerService : IHeroPowerService
    {
        private readonly DataContext _context;

        public HeroPowerService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HeroPower>> GetAllHeroPowersAsync()
        {
            return await _context.HeroPowers.ToListAsync();
        }

        public async Task<HeroPower> AddHeroPowerAsync(HeroPower heroPower)
        {
            _context.HeroPowers.Add(heroPower);
            await _context.SaveChangesAsync();
            return heroPower;
        }

        public async Task<HeroPower> DeleteHeroPowerAsync(int heroId, int powerId)
        {
            var heroPower = await _context.HeroPowers
                .FirstOrDefaultAsync(hp => hp.HeroId == heroId && hp.PowerId == powerId);
            if (heroPower != null)
            {
                _context.HeroPowers.Remove(heroPower);
                await _context.SaveChangesAsync();
            }
            return heroPower;
        }
    }
}
