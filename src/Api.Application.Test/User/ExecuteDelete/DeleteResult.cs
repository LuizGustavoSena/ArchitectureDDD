using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Service.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.ExecuteDelete
{
    public class DeleteResult
    {
        private UsersController _controllers;

        [Fact(DisplayName = "Should correct result Delete")]
        public async Task Delete()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(x => x.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _controllers = new UsersController(serviceMock.Object);

            var result = await _controllers.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValues = ((OkObjectResult)result).Value;
            Assert.NotNull(resultValues);
            Assert.True((Boolean)resultValues);

            serviceMock.Setup(x => x.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _controllers = new UsersController(serviceMock.Object);

            var resultFailed = await _controllers.Delete(Guid.NewGuid());
            Assert.True(resultFailed is OkObjectResult);

            var resultFailedValues = ((OkObjectResult)resultFailed).Value;
            Assert.NotNull(resultFailedValues);
            Assert.False((Boolean)resultFailedValues);
        }
    }
}