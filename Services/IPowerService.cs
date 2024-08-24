using heroAPI.Models;

namespace heroAPI.Services
{
    public interface IPowerService
    {
        Task<IEnumerable<Power>> GetAllPowersAsync();
        Task<Power> GetPowerByIdAsync(int id);
        Task<Power> AddPowerAsync(Power power);
        Task<Power> UpdatePowerAsync(Power power);
        Task<Power> DeletePowerAsync(Power power);

    }
}

