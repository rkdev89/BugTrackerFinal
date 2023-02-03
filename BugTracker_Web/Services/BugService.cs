using BugTracker_Utility;
using BugTracker_Web.Models;
using BugTracker_Web.Models.Dto;
using BugTracker_Web.Services.IServices;
using static BugTracker_Utility.SD;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace BugTracker_Web.Services
{
    public class BugService : BaseService, IBugService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string bugUrl;
        public BugService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            bugUrl = configuration.GetValue<string>("ServiceUrls:BugTrackerAPI");
        }

        public Task<T> CreateAsync<T>(BugCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.POST,
                Data = dto,
                Url = bugUrl + "/api/BugAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.DELETE,
                Url = bugUrl + "/api/BugAPI/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = bugUrl + "/api/BugAPI"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = bugUrl + "/api/BugAPI/" + id
            });
        }

        public Task<T> UpdateAsync<T>(BugUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = bugUrl + "/api/BugAPI/"+ dto.Id
            });
        }
    }
}
