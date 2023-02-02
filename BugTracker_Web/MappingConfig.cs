using AutoMapper;
using BugTracker_Web.Models;
using BugTracker_Web.Models.Dto;

namespace BugTracker_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<BugDTO, BugCreateDTO>().ReverseMap();
            CreateMap<UserDTO, UserCreateDTO>().ReverseMap();
            CreateMap<BugDTO, BugUpdateDTO>().ReverseMap();
            CreateMap<UserDTO, UserUpdateDTO>().ReverseMap();
        }
    }
}
