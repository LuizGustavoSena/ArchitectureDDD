using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappgins
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>()
                .ReverseMap();

            CreateMap<StateEntity, StateModel>()
                .ReverseMap();

            CreateMap<CityEntity, CityModel>()
                .ForMember(d => d.Code, i => i.MapFrom(x => x.Cod))
                .ReverseMap();

            CreateMap<ZipCodeEntity, ZipCodeModel>()
                .ReverseMap();
        }
    }
}