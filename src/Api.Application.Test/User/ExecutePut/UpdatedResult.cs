using System;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Service.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.ExecutePut
{
    public class UpdatedResult
    {
        private UsersController _controller;

        [Fact(DisplayName = "Should currect result put")]
        public async void Put()
        {
            var userDtoUpdate = new UserDtoUpdate
            {
                Email = "Any_Email",
                Name = "Any_Name",
                Id = Guid.NewGuid()
            };
            var UserDtoUpdateResult = new UserDtoUpdateResult
            {
                Email = userDtoUpdate.Email,
                Name = userDtoUpdate.Name,
                UpdateAt = DateTime.UtcNow
            };

            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(x => x.Put(It.IsAny<UserDtoUpdate>())).ReturnsAsync(UserDtoUpdateResult);
            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.Put(userDtoUpdate);
            Assert.True(result is OkObjectResult);

            var resultValues = ((OkObjectResult)result).Value as UserDtoUpdateResult;
            Assert.NotNull(resultValues);
            Assert.Equal(userDtoUpdate.Email, resultValues.Email);
            Assert.Equal(userDtoUpdate.Name, resultValues.Name);
        }
    }
}