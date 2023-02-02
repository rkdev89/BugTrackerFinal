using Microsoft.AspNetCore.Mvc;
using static BugTracker_Utility.SD;

namespace BugTracker_Web.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
