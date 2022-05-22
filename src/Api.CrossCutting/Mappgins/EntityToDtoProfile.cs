using Api.Domain.Dtos.City;
using Api.Domain.Dtos.State;
using Api.Domain.Dtos.User;
using Api.Domain.Dtos.ZipCode;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappgins
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>()
                .ReverseMap();

            CreateMap<UserDtoCreateResult, UserEntity>()
                .ReverseMap();

            CreateMap<UserDtoUpdateResult, UserEntity>()
                .ReverseMap();

            CreateMap<StateDto, StateEntity>()
                .ReverseMap();

            CreateMap<ZipCodeDto, ZipCodeEntity>()
                .ReverseMap();

            CreateMap<ZipCodeDtoCreateResult, ZipCodeEntity>()
                .ReverseMap();

            CreateMap<ZipCodeDtoUpdateResult, ZipCodeEntity>()
                .ReverseMap();

            CreateMap<CityDto, CityEntity>()
                .ReverseMap();

            CreateMap<CityDtoComplete, CityEntity>()
               .ReverseMap();

            CreateMap<CityDtoCreateResult, CityEntity>()
               .ReverseMap();

            CreateMap<ZipCodeDtoUpdateResult, CityEntity>()
               .ReverseMap();
        }
    }
}