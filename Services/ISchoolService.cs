using heroAPI.Models;

namespace heroAPI.Services
{
    public interface ISchoolService
    {
        Task<IEnumerable<School>> GetAllSchoolsAsync();
        Task<School> GetSchoolByIdAsync(int id);
        Task<School> AddSchoolAsync(Hero hero);
        Task<School> UpdateSchoolAsync(Hero hero);
        Task<School> DeleteSchoolAsync(Hero hero);
    }
}
