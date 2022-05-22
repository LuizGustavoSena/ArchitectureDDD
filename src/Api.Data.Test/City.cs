using System;
using System.Linq;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class City : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;
        public City(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Should correct result CRUD Cities")]
        public async void CRUD()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                var _repository = new CityImplementations(context);
                var cityEntity = new CityEntity
                {
                    Cod = 159753,
                    name = "Any_City",
                    StateId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                };

                var result = await _repository.InsertAsync(cityEntity);
                Assert.NotNull(result);
                Assert.Equal(cityEntity.Cod, result.Cod);
                Assert.Equal(cityEntity.name, result.name);
                Assert.Equal(cityEntity.StateId, result.StateId);
                Assert.True(result.Id != null);

                var resultSelect = await _repository.SelectAsync(cityEntity.Id);
                Assert.NotNull(resultSelect);
                Assert.Equal(cityEntity.Cod, resultSelect.Cod);
                Assert.Equal(cityEntity.name, resultSelect.name);
                Assert.Equal(cityEntity.StateId, resultSelect.StateId);

                var resultCompletedSelectByCode = await _repository.GetCompleteByCode(cityEntity.Cod);
                Assert.NotNull(resultCompletedSelectByCode);
                Assert.NotNull(resultCompletedSelectByCode.State);
                Assert.Equal(cityEntity.Cod, resultCompletedSelectByCode.Cod);
                Assert.Equal(cityEntity.name, resultCompletedSelectByCode.name);
                Assert.Equal(cityEntity.StateId, resultCompletedSelectByCode.StateId);

                var resultCompletedSelectById = await _repository.GetCompleteById(cityEntity.Id);
                Assert.NotNull(resultCompletedSelectById);
                Assert.NotNull(resultCompletedSelectById.State);
                Assert.Equal(cityEntity.Cod, resultCompletedSelectById.Cod);
                Assert.Equal(cityEntity.name, resultCompletedSelectById.name);
                Assert.Equal(cityEntity.StateId, resultCompletedSelectById.StateId);

                var resultSelectAll = await _repository.SelectAsync();
                Assert.NotNull(resultSelectAll);
                Assert.True(resultSelectAll.Count() > 0);

                cityEntity.name = "Other_Name";
                cityEntity.Id = result.Id;
                var resultEdit = await _repository.UpdateAsync(cityEntity);
                Assert.NotNull(resultEdit);
                Assert.Equal(cityEntity.Cod, resultEdit.Cod);
                Assert.Equal(cityEntity.name, resultEdit.name);
                Assert.Equal(cityEntity.StateId, resultEdit.StateId);
                Assert.Equal(cityEntity.Id, resultEdit.Id);
                Assert.True(resultEdit.UpdateAt != null);

                var resultDeleted = await _repository.DeleteAsync(cityEntity.Id);
                Assert.NotNull(resultDeleted);
                Assert.True(resultDeleted);

                var resultSelectAllEmpty = await _repository.SelectAsync();
                Assert.NotNull(resultSelectAllEmpty);
                Assert.True(resultSelectAllEmpty.Count() == 0);

                var resultEmpty = await _repository.SelectAsync(cityEntity.Id);
                Assert.Null(resultEmpty);
            }
        }
    }
}