using AutoMapper;
using Entities.Model;

namespace Entities.Mappers {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<UserRegistrationModel, UserModel>()
                .ForMember(u => u.FirstName, ur => ur.MapFrom(o => o.UserName)); 
        }
    }
}
