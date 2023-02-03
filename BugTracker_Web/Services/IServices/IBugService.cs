using BugTracker_Web.Models.Dto;

namespace BugTracker_Web.Services.IServices
{
    public interface IBugService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(BugCreateDTO dto);
        Task<T> UpdateAsync<T>(BugUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
