using heroAPI.Models;

namespace heroAPI.Services.HeroPowerService
{
    public interface IHeroPowerService
    {
        Task<IEnumerable<HeroPower>> GetAllHeroPowersAsync();
        Task<HeroPower> AddHeroPowerAsync(HeroPower heroPower);
        Task<HeroPower> DeleteHeroPowerAsync(int heroId, int powerId);
    }
}

