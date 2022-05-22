using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.City;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.Mappings
{
    public class CityMapper : BaseTestService
    {
        [Fact(DisplayName = "Should correct mapper City")]
        public void CorrectMapper()
        {
            var model = new CityModel
            {
                Id = Guid.NewGuid(),
                Name = "Any_Name",
                Code = 1597536,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
                StateId = Guid.NewGuid()
            };

            var listEntity = new List<CityEntity>();
            for (int i = 0; i < 5; i++)
            {
                listEntity.Add(new CityEntity
                {
                    Id = Guid.NewGuid(),
                    name = $"Any_Name{i}",
                    Cod = 123456,
                    StateId = Guid.NewGuid(),
                    State = new StateEntity
                    {
                        Id = Guid.NewGuid(),
                        Initials = "AS{i}",
                        Name = $"Any_Name{i}"
                    },
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                });
            }

            var entity = Mapper.Map<CityEntity>(model);
            Assert.NotNull(entity);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.name, model.Name);
            Assert.Equal(entity.StateId, model.StateId);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);
            Assert.Equal(entity.Cod, model.Code);

            var dtoCreate = Mapper.Map<CityDtoCreate>(model);
            Assert.NotNull(dtoCreate);
            Assert.Equal(dtoCreate.Name, model.Name);
            Assert.Equal(dtoCreate.StateId, model.StateId);
            Assert.Equal(dtoCreate.Cod, model.Code);

            var dtoUpdate = Mapper.Map<CityDtoUpdate>(model);
            Assert.NotNull(dtoUpdate);
            Assert.Equal(dtoUpdate.Name, model.Name);
            Assert.Equal(dtoUpdate.StateId, model.StateId);
            Assert.Equal(dtoUpdate.Cod, model.Code);

            var stateDto = Mapper.Map<CityDto>(entity);
            Assert.NotNull(stateDto);
            Assert.Equal(stateDto.Id, entity.Id);
            Assert.Equal(stateDto.Name, entity.name);
            Assert.Equal(stateDto.StateId, entity.StateId);
            Assert.Equal(stateDto.Cod, entity.Cod);

            var stateDtoResult = Mapper.Map<CityDtoCreateResult>(entity);
            Assert.NotNull(stateDtoResult);
            Assert.Equal(stateDtoResult.Id, entity.Id);
            Assert.Equal(stateDtoResult.Name, entity.name);
            Assert.Equal(stateDtoResult.StateId, entity.StateId);
            Assert.Equal(stateDtoResult.Cod, entity.Cod);

            var stateDtoUpdateResult = Mapper.Map<CityDtoUpdateResult>(entity);
            Assert.NotNull(stateDtoUpdateResult);
            Assert.Equal(stateDtoUpdateResult.Id, entity.Id);
            Assert.Equal(stateDtoUpdateResult.Name, entity.name);
            Assert.Equal(stateDtoUpdateResult.StateId, entity.StateId);
            Assert.Equal(stateDtoUpdateResult.Cod, entity.Cod);
            Assert.Equal(stateDtoUpdateResult.UpdateAt, entity.UpdateAt);

            var listStateDot = Mapper.Map<List<CityDto>>(listEntity);
            Assert.NotNull(listStateDot);
            Assert.True(listStateDot.Count() == listEntity.Count());
            for (int i = 0; i < listStateDot.Count(); i++)
            {
                Assert.Equal(listStateDot[i].Id, listEntity[i].Id);
                Assert.Equal(listStateDot[i].Name, listEntity[i].name);
                Assert.Equal(listStateDot[i].StateId, listEntity[i].StateId);
                Assert.Equal(listStateDot[i].Cod, listEntity[i].Cod);
            }
        }
    }
}