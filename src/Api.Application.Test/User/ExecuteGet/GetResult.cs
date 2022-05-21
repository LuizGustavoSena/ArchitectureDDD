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
    public class GetResult
    {
        private UsersController _controller;

        [Fact(DisplayName = "Should sucess get user")]
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

            var result = await _controller.Get(userDto.Id);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UserDto;
            Assert.NotNull(resultValue);
            Assert.Equal(userDto.Name, resultValue.Name);
            Assert.Equal(userDto.Email, resultValue.Email);
            Assert.Equal(userDto.Id, resultValue.Id);

            serviceMock.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(null as UserDto);
            _controller = new UsersController(serviceMock.Object);

            var resultEmpty = await _controller.Get(userDto.Id);
            Assert.True(resultEmpty is OkObjectResult);

            var resultEmptyValue = ((OkObjectResult)resultEmpty).Value as UserDto;
            Assert.Null(resultEmptyValue);
        }
    }
}