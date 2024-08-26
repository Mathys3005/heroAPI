using heroAPI.Models;

namespace heroAPI.Services.HeroService
{
    public interface IHeroService
    {
        Task<IEnumerable<Hero>> GetAllHeroesAsync();
        Task<Hero> GetHeroByIdAsync(int id);
        Task<Hero> AddHeroAsync(Hero hero);
        Task<Hero> UpdateHeroAsync(Hero hero);
        Task<Hero> DeleteHeroAsync(Hero hero);

    }
}
