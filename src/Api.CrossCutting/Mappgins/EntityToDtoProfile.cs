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
                .ForMember(d => d.name, i => i.MapFrom(x => x.Name))
                .ReverseMap();

            CreateMap<CityDtoComplete, CityEntity>()
                .ForMember(d => d.name, i => i.MapFrom(x => x.Name))
                .ReverseMap();

            CreateMap<CityDtoCreateResult, CityEntity>()
                .ForMember(d => d.name, i => i.MapFrom(x => x.Name))
                .ReverseMap();

            CreateMap<CityDtoUpdateResult, CityEntity>()
                .ForMember(d => d.name, i => i.MapFrom(x => x.Name))
                .ReverseMap();

            CreateMap<ZipCodeDtoUpdateResult, CityEntity>()
               .ReverseMap();
        }
    }
}