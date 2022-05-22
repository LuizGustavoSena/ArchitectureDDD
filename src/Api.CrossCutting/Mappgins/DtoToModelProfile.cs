using Api.Domain.Dtos.City;
using Api.Domain.Dtos.State;
using Api.Domain.Dtos.User;
using Api.Domain.Dtos.ZipCode;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappgins
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>()
                .ReverseMap();

            CreateMap<UserModel, UserDtoCreate>()
                .ReverseMap();

            CreateMap<UserModel, UserDtoUpdate>()
                .ReverseMap();

            CreateMap<StateModel, StateDto>()
                .ReverseMap();

            CreateMap<CityModel, CityDto>()
                .ReverseMap();

            CreateMap<CityModel, CityDtoCreate>()
                .ReverseMap();

            CreateMap<CityModel, CityDtoUpdate>()
                .ReverseMap();

            CreateMap<ZipCodeModel, ZipCodeDto>()
                .ReverseMap();

            CreateMap<ZipCodeModel, ZipCodeDtoCreate>()
                .ReverseMap();

            CreateMap<ZipCodeModel, ZipCodeDtoUpdate>()
                .ReverseMap();
        }
    }
}