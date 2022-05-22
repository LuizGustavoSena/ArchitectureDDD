using System;
using System.Linq;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class StateGetAll : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;
        public StateGetAll(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Should correct result Get")]
        public async void Get()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                var _repository = new StateImplementations(context);
                var stateEntity = new StateEntity
                {
                    Id = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                    Initials = "SP",
                    Name = "São Paulo",
                };

                var result = await _repository.SelectAsync(stateEntity.Id);
                Assert.NotNull(result);
                Assert.Equal(stateEntity.Id, result.Id);
                Assert.Equal(stateEntity.Initials, result.Initials);
                Assert.Equal(stateEntity.Name, result.Name);

                var resultAll = await _repository.SelectAsync();
                Assert.NotNull(resultAll);
                Assert.True(resultAll.Count() == 27);
            }
        }
    }
}