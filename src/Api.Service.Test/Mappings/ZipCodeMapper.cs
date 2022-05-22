using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.ZipCode;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.Mappings
{
    public class ZipCodeMapper : BaseTestService
    {
        [Fact(DisplayName = "Should correct mapper ZipCode")]
        public void MapperZipCode()
        {
            var model = new ZipCodeModel
            {
                Code = 4561,
                Street = "Any_Street_Model",
                Number = "4561",
                CityId = Guid.NewGuid()
            };

            var listEntity = new List<ZipCodeEntity>();
            for (int i = 0; i < 3; i++)
            {
                listEntity.Add(new ZipCodeEntity
                {
                    Id = Guid.NewGuid(),
                    Code = 78945612,
                    CityId = Guid.NewGuid(),
                    City = new CityEntity
                    {
                        Id = Guid.NewGuid(),
                        name = "Any_Name",
                        Cod = 123456,
                        StateId = Guid.NewGuid(),
                        State = new StateEntity
                        {
                            Id = Guid.NewGuid(),
                            Initials = "AS",
                            Name = "Any_Name"
                        },
                        CreateAt = DateTime.UtcNow,
                        UpdateAt = DateTime.UtcNow
                    },
                    Street = "Any_Street",
                    Number = "456123",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                });
            };

            var dto = Mapper.Map<ZipCodeDto>(model);
            Assert.NotNull(dto);
            Assert.Equal(dto.CityId, model.CityId);
            Assert.Equal(dto.Number, model.Number);
            Assert.Equal(dto.Street, model.Street);
            Assert.Equal(dto.Code, model.Code);

            var dtoCreate = Mapper.Map<ZipCodeDtoCreate>(model);
            Assert.NotNull(dtoCreate);
            Assert.Equal(dtoCreate.CityId, model.CityId);
            Assert.Equal(dtoCreate.Number, model.Number);
            Assert.Equal(dtoCreate.Street, model.Street);
            Assert.Equal(dtoCreate.Code, model.Code);

            var modelCreate = Mapper.Map<ZipCodeModel>(dtoCreate);
            Assert.NotNull(modelCreate);
            Assert.Equal(modelCreate.CityId, dtoCreate.CityId);
            Assert.Equal(modelCreate.Number, dtoCreate.Number);
            Assert.Equal(modelCreate.Street, dtoCreate.Street);
            Assert.Equal(modelCreate.Code, dtoCreate.Code);

            var dtoUpdate = Mapper.Map<ZipCodeDtoUpdate>(model);
            Assert.NotNull(dtoUpdate);
            Assert.Equal(dtoUpdate.CityId, model.CityId);
            Assert.Equal(dtoUpdate.Number, model.Number);
            Assert.Equal(dtoUpdate.Street, model.Street);
            Assert.Equal(dtoUpdate.Code, model.Code);

            var modelUpdate = Mapper.Map<ZipCodeModel>(dtoUpdate);
            Assert.NotNull(modelUpdate);
            Assert.Equal(modelUpdate.CityId, dtoCreate.CityId);
            Assert.Equal(modelUpdate.Number, dtoCreate.Number);
            Assert.Equal(modelUpdate.Street, dtoCreate.Street);
            Assert.Equal(modelUpdate.Code, dtoCreate.Code);

            var entity = Mapper.Map<ZipCodeEntity>(model);
            Assert.NotNull(entity);
            Assert.Equal(entity.CityId, dtoCreate.CityId);
            Assert.Equal(entity.Number, dtoCreate.Number);
            Assert.Equal(entity.Street, dtoCreate.Street);
            Assert.Equal(entity.Code, dtoCreate.Code);

            var listDto = Mapper.Map<List<ZipCodeDto>>(listEntity);
            Assert.NotNull(listDto);
            Assert.True(listDto.Count() == listEntity.Count());
            for (int i = 0; i < listDto.Count(); i++)
            {
                Assert.Equal(listDto[i].CityId, listEntity[i].CityId);
                Assert.Equal(listDto[i].Number, listEntity[i].Number);
                Assert.Equal(listDto[i].Street, listEntity[i].Street);
                Assert.Equal(listDto[i].Code, listEntity[i].Code);
            }
        }
    }
}