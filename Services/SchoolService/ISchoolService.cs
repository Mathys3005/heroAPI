using heroAPI.Models;

namespace heroAPI.Services.SchoolService
{
    public interface ISchoolService
    {
        Task<IEnumerable<School>> GetAllSchoolsAsync();
        Task<School> GetSchoolByIdAsync(int id);
        Task<School> AddSchoolAsync(School school);
        Task<School> UpdateSchoolAsync(School school);
        Task<School> DeleteSchoolAsync(School school);
    }
}
