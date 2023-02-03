using BugTracker_Web.Models.Dto;

namespace BugTracker_Web.Services.IServices
{
    public interface IUserService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(UserCreateDTO dto);
        Task<T> UpdateAsync<T>(UserUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
