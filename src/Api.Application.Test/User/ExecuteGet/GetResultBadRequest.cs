using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Service.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.ExecuteGet
{
    public class GetResultBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "Should BadRequest get user")]
        public async Task Get()
        {
            var userDto = new UserDto
            {
                Email = "Any_Email",
                Name = "Any_Name",
                CreateAt = DateTime.UtcNow,
                Id = Guid.NewGuid()
            };

            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(userDto);

            _controller = new UsersController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Campo obrigatório");

            var result = await _controller.Get(userDto.Id);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}