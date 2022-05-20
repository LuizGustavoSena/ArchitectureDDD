using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class CrudUserCompleted : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider { get; set; }
        public CrudUserCompleted(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }
        [Fact(DisplayName = "Should currect crud user")]
        [Trait("CRUD", "UserEntity")]
        public async Task ItsPossibleMakeCrud()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                var _userImplementation = new UserImplementations(context);
                var _entity = new UserEntity
                {
                    Email = "test@email.com",
                    Name = "TestName"
                };

                var resultInsert = await _userImplementation.InsertAsync(_entity);

                Assert.NotNull(resultInsert);
                Assert.Equal(_entity.Email, resultInsert.Email);
                Assert.Equal(_entity.Name, resultInsert.Name);
                Assert.False(resultInsert.Id == Guid.Empty);

                _entity.Name = "UpdatedName";
                _entity.Email = "UpdatedEmail";
                var resultUpdate = await _userImplementation.UpdateAsync(_entity);

                Assert.NotNull(resultUpdate);
                Assert.NotNull(resultUpdate.UpdateAt);
                Assert.Equal(_entity.Email, resultUpdate.Email);
                Assert.Equal(_entity.Name, resultUpdate.Name);

                var resultSelect = await _userImplementation.SelectAsync(_entity.Id);

                Assert.NotNull(resultSelect);
                Assert.Equal(_entity.Id, resultSelect.Id);
                Assert.Equal(_entity.Email, resultUpdate.Email);
                Assert.Equal(_entity.Name, resultUpdate.Name);

                var resultFindByEmail = await _userImplementation.FindByEmal(_entity.Email);

                Assert.NotNull(resultFindByEmail);
                Assert.Equal(_entity.Email, resultFindByEmail.Email);
                Assert.Equal(_entity.Name, resultFindByEmail.Name);

                var resultSelectAll = await _userImplementation.SelectAsync();

                Assert.NotNull(resultSelectAll);
                Assert.True(resultSelectAll.Count() > 0);

                var resultDeleted = await _userImplementation.DeleteAsync(_entity.Id);

                Assert.True(resultDeleted);

                var resultSelectAllEmpty = await _userImplementation.SelectAsync();

                Assert.NotNull(resultSelectAll);
                Assert.True(resultSelectAllEmpty.Count() == 0);
            }
        }
    }
}