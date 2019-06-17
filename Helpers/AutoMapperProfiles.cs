using AutoMapper;
using identity_rest_service.Dtos;
using identity_rest_service.Models;

namespace identity_rest_service.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, UserToReturnDto>();

            CreateMap<UserProfile, UserProfileToReturnDto>();

            CreateMap<UserType, UserTypeToReturnDto>();

            CreateMap<AgentProfile, AgentProfileToReturnDto>();

            CreateMap<ErrorHandle<string>, ErrorToReturnDto>();
        }
    }
}