using System;
using System.Linq;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class ZipCode : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;
        public ZipCode(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Should correct result CRUD Cities")]
        public async void CRUD()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                var _repositoryCity = new CityImplementations(context);
                var cityEntity = new CityEntity
                {
                    Cod = 159753,
                    name = "Any_City",
                    StateId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                };
                var result = await _repositoryCity.InsertAsync(cityEntity);

                var _repository = new ZipCodeImplementations(context);
                var zipCodeEntity = new ZipCodeEntity
                {
                    CityId = cityEntity.Id,
                    Code = 15975342,
                    Number = 123,
                    Street = "Any_Street",
                };

                var resultZipCode = await _repository.InsertAsync(zipCodeEntity);
                Assert.NotNull(resultZipCode);
                Assert.Equal(zipCodeEntity.Code, resultZipCode.Code);
                Assert.Equal(zipCodeEntity.Street, resultZipCode.Street);
                Assert.Equal(zipCodeEntity.CityId, resultZipCode.CityId);

                var resultSelect = await _repository.SelectAsync(resultZipCode.Id);
                Assert.NotNull(resultSelect);
                Assert.Equal(zipCodeEntity.Code, resultSelect.Code);
                Assert.Equal(zipCodeEntity.Street, resultSelect.Street);
                Assert.Equal(zipCodeEntity.CityId, resultSelect.CityId);

                var resultSelectByCode = await _repository.SelectAsync(zipCodeEntity.Code);
                Assert.NotNull(resultSelectByCode);
                Assert.Equal(zipCodeEntity.Code, resultSelectByCode.Code);
                Assert.Equal(zipCodeEntity.Street, resultSelectByCode.Street);
                Assert.Equal(zipCodeEntity.CityId, resultSelectByCode.CityId);
                Assert.Equal(zipCodeEntity.Number, resultSelectByCode.Number);

                var resultSelectAll = await _repository.SelectAsync();
                Assert.NotNull(resultSelectAll);
                Assert.True(resultSelectAll.Count() > 0);

                zipCodeEntity.Street = "Other_Street";
                zipCodeEntity.Id = resultZipCode.Id;
                var resultEdit = await _repository.UpdateAsync(zipCodeEntity);
                Assert.NotNull(resultEdit);
                Assert.Equal(zipCodeEntity.Code, resultEdit.Code);
                Assert.Equal(zipCodeEntity.Street, resultEdit.Street);
                Assert.Equal(zipCodeEntity.Number, resultEdit.Number);
                Assert.Equal(zipCodeEntity.Id, resultEdit.Id);
                Assert.True(resultEdit.UpdateAt != null);

                var resultDeleted = await _repository.DeleteAsync(zipCodeEntity.Id);
                Assert.NotNull(resultDeleted);
                Assert.True(resultDeleted);

                var resultSelectAllEmpty = await _repository.SelectAsync();
                Assert.NotNull(resultSelectAllEmpty);
                Assert.True(resultSelectAllEmpty.Count() == 0);

                var resultEmpty = await _repository.SelectAsync(zipCodeEntity.Id);
                Assert.Null(resultEmpty);
            }
        }
    }
}