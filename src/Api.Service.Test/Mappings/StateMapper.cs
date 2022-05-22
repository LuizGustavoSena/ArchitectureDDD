using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.State;
using Api.Domain.Entities;
using Api.Domain.Models;
using Xunit;

namespace Api.Service.Test.Mappings
{
    public class StateMapper : BaseTestService
    {
        [Fact(DisplayName = "Should correct mapper State")]
        public void CorrectMapper()
        {
            var model = new StateModel
            {
                Id = Guid.NewGuid(),
                Name = "Any_Name",
                Initials = "AS",
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listEntity = new List<StateEntity>();
            for (int i = 0; i < 5; i++)
            {
                listEntity.Add(new StateEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Any_Name",
                    Initials = "AS",
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                });
            }

            var entity = Mapper.Map<StateEntity>(model);
            Assert.NotNull(entity);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.Initials, model.Initials);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            var stateDto = Mapper.Map<StateDto>(entity);
            Assert.NotNull(entity);
            Assert.Equal(stateDto.Id, model.Id);
            Assert.Equal(stateDto.Name, model.Name);
            Assert.Equal(stateDto.Initials, model.Initials);

            var listStateDot = Mapper.Map<List<StateDto>>(listEntity);
            Assert.NotNull(listStateDot);
            Assert.True(listStateDot.Count() == listEntity.Count());
            for (int i = 0; i < listStateDot.Count(); i++)
            {
                Assert.Equal(listStateDot[i].Id, listEntity[i].Id);
                Assert.Equal(listStateDot[i].Name, listEntity[i].Name);
                Assert.Equal(listStateDot[i].Initials, listEntity[i].Initials);
            }

            var stateModelToDto = Mapper.Map<StateDto>(model);
            Assert.NotNull(entity);
            Assert.Equal(stateModelToDto.Id, model.Id);
            Assert.Equal(stateModelToDto.Name, model.Name);
            Assert.Equal(stateModelToDto.Initials, model.Initials);
        }
    }
}