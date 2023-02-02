using AutoMapper;
using BugTracker_API.Models;
using BugTracker_API.Models.Dto;

namespace BugTracker_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Bug, BugDTO>();
            CreateMap<BugDTO, Bug>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Bug, BugCreateDTO>().ReverseMap();
            CreateMap<User, UserCreateDTO>().ReverseMap();

            CreateMap<Bug, BugUpdateDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();
        }
    }
}
