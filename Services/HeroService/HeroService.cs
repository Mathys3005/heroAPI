using heroAPI.Data;
using heroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace heroAPI.Services.HeroService
{
    public class HeroService : IHeroService
    {
        private readonly DataContext _context;

        public HeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hero>> GetAllHeroesAsync()
        {
            return await _context.Hero.ToListAsync();
        }

        public async Task<Hero> GetHeroByIdAsync(int id)
        {
            return await _context.Hero
                .Include(h => h.Powers) 
                .FirstOrDefaultAsync(h => h.HeroId == id);
        }

        public async Task<Hero> AddHeroAsync(Hero hero)
        {
            _context.Hero.Add(hero);
            await _context.SaveChangesAsync();
            return hero;
        }

        public async Task<Hero> UpdateHeroAsync(Hero hero)
        {
            _context.Entry(hero).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hero;
        }

        public async Task<Hero> DeleteHeroAsync(Hero hero)
        {
            _context.Hero.Remove(hero);
            await _context.SaveChangesAsync();
            return hero;
        }
    }
}
