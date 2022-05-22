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
                .ReverseMap();

            CreateMap<ZipCodeEntity, ZipCodeModel>()
                .ReverseMap();
        }
    }
}