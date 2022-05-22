using System;
using System.Collections.Generic;
using Api.Domain.Dtos.City;
using Api.Domain.Dtos.State;
using Api.Domain.Dtos.ZipCode;

namespace Api.Service.Test.Municipio
{
    public class ZipCodTests
    {
        public static int Code { get; set; }
        public static string Street { get; set; }
        public static string Number { get; set; }
        public static int CodeAltered { get; set; }
        public static string StreetAltered { get; set; }
        public static string NumberAltered { get; set; }
        public static Guid CityId { get; set; }
        public static Guid CodeId { get; set; }

        public List<ZipCodeDto> listaDto = new List<ZipCodeDto>();
        public ZipCodeDto zipCodeDto;
        public ZipCodeDtoCreate zipCodeDtoCreate;
        public ZipCodeDtoCreateResult zipCodeDtoCreateResult;
        public ZipCodeDtoUpdate zipCodeDtoUpdate;
        public ZipCodeDtoUpdateResult zipCodeDtoUpdateResult;

        public ZipCodTests()
        {
            CityId = Guid.NewGuid();
            CodeId = Guid.NewGuid();
            Code = Code;
            Number = "456123";
            Street = "Any_Street";
            CodeAltered = 4562354;
            NumberAltered = "15975";
            StreetAltered = "Other_Street";

            for (int i = 0; i < 10; i++)
            {
                var dto = new ZipCodeDto()
                {
                    Id = Guid.NewGuid(),
                    Code = 456123,
                    Street = "Any_Street",
                    Number = "456123",
                    CityId = Guid.NewGuid(),
                    City = new CityDtoComplete
                    {
                        Id = CityId,
                        Name = "Any_Name",
                        Cod = 159756,
                        StateId = Guid.NewGuid(),
                        State = new StateDto
                        {
                            Id = Guid.NewGuid(),
                            Name = "Any_Name",
                            Initials = "AN"
                        }
                    }
                };
                listaDto.Add(dto);
            }

            zipCodeDto = new ZipCodeDto
            {
                Id = CityId,
                Code = 159753,
                Street = Street,
                Number = Number,
                CityId = CityId,
                City = new CityDtoComplete
                {
                    Id = CityId,
                    Name = "Any_Name",
                    Cod = 159753,
                    StateId = Guid.NewGuid(),
                    State = new StateDto
                    {
                        Id = Guid.NewGuid(),
                        Name = "Any_Name",
                        Initials = "AN"
                    }
                }
            };

            zipCodeDtoCreate = new ZipCodeDtoCreate
            {
                Code = 1597853,
                Street = Street,
                Number = Number,
                CityId = CityId,
            };

            zipCodeDtoCreateResult = new ZipCodeDtoCreateResult
            {
                Id = CodeId,
                Code = 1597853,
                Street = Street,
                Number = Number,
                CityId = CityId,
                CreateAt = DateTime.UtcNow
            };

            zipCodeDtoUpdate = new ZipCodeDtoUpdate
            {
                Id = CodeId,
                Code = 1597853,
                Street = Street,
                Number = Number,
                CityId = CityId
            };

            zipCodeDtoUpdateResult = new ZipCodeDtoUpdateResult
            {
                Id = CodeId,
                Code = CodeAltered,
                Street = Street,
                Number = Number,
                CityId = CityId,
                UpdateAt = DateTime.UtcNow
            };

        }
    }
}
