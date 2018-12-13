using AutoMapper;
using Khan.Common.Entities;
using Khan.Common.ViewModel.Authorization;

namespace Khan.Serevices.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<UserEntity, LoginViewModel>().ReverseMap();
        }
    }
}
