using BugTracker_Utility;
using BugTracker_Web.Models;
using BugTracker_Web.Models.Dto;
using BugTracker_Web.Services.IServices;

namespace BugTracker_Web.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string userUrl;
        public UserService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            userUrl = configuration.GetValue<string>("ServiceUrls:BugTrackerAPI");
        }
        public Task<T> CreateAsync<T>(UserCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = userUrl + "/api/UserAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = userUrl + "/api/UserAPI/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = userUrl + "/api/UserAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = userUrl + "/api/UserAPI/" + id
            });
        }

        public Task<T> UpdateAsync<T>(UserUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = userUrl + "/api/UserAPI/" + dto.Id
            });
        }
    }
}
