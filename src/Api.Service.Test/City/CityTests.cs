using System;
using System.Collections.Generic;
using Api.Domain.Dtos.City;
using Api.Domain.Dtos.State;

namespace Api.Service.Test.Municipio
{
    public class CityTests
    {
        public static string CityName { get; set; }
        public static int CityCode { get; set; }
        public static string CityNameAltered { get; set; }
        public static int CityCodeAltered { get; set; }
        public static Guid CityId { get; set; }
        public static Guid StateId { get; set; }

        public List<CityDto> listaDto = new List<CityDto>();
        public CityDto cityDto;
        public CityDtoComplete cityDtoComplete;
        public CityDtoCreate cityDtoCreate;
        public CityDtoCreateResult cityDtoCreateResult;
        public CityDtoUpdate cityDtoUpdate;
        public CityDtoUpdateResult cityDtoUpdateResult;

        public CityTests()
        {
            CityId = Guid.NewGuid();
            CityName = "Any_Name";
            CityCode = 159456;
            CityNameAltered = "Any_Number";
            CityCodeAltered = 789456;
            StateId = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var dto = new CityDto()
                {
                    Id = Guid.NewGuid(),
                    Name = "Any_Name",
                    Cod = 159789,
                    StateId = Guid.NewGuid()
                };
                listaDto.Add(dto);
            }

            cityDto = new CityDto
            {
                Id = CityId,
                Name = CityName,
                Cod = CityCode,
                StateId = StateId
            };

            cityDtoComplete = new CityDtoComplete
            {
                Id = CityId,
                Name = CityName,
                Cod = CityCode,
                StateId = StateId,
                State = new StateDto
                {
                    Id = Guid.NewGuid(),
                    Name = "Any_Name",
                    Initials = "AS"
                }
            };

            cityDtoCreate = new CityDtoCreate
            {
                Name = CityName,
                Cod = CityCode,
                StateId = StateId
            };

            cityDtoCreateResult = new CityDtoCreateResult
            {
                Id = CityId,
                Name = CityName,
                Cod = CityCode,
                StateId = StateId,
                CreateAt = DateTime.UtcNow
            };

            cityDtoUpdate = new CityDtoUpdate
            {
                Id = CityId,
                Name = CityNameAltered,
                Cod = CityCodeAltered,
                StateId = StateId
            };

            cityDtoUpdateResult = new CityDtoUpdateResult
            {
                Id = CityId,
                Name = CityNameAltered,
                Cod = CityCodeAltered,
                StateId = StateId,
                UpdateAt = DateTime.UtcNow
            };

        }
    }
}
