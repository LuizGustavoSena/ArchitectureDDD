using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Service.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.ExecutePut
{
    public class UpdatedResultBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "Should BadRequest result put")]
        public async Task Put()
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
            _controller.ModelState.AddModelError("Nome", "Campo obrigatório");

            var result = await _controller.Put(userDtoUpdate);
            Assert.True(result is BadRequestObjectResult);

            serviceMock.Setup(x => x.Put(It.IsAny<UserDtoUpdate>())).ReturnsAsync(null as UserDtoUpdateResult);
            _controller = new UsersController(serviceMock.Object);

            var resultEmpty = await _controller.Put(userDtoUpdate);
            Assert.True(resultEmpty is BadRequestResult);
        }
    }
}