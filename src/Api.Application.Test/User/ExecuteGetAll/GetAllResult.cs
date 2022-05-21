using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Service.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.ExecuteGetAll
{
    public class GetAllResult
    {
        private UsersController _controller;

        [Fact(DisplayName = "Should sucess GetAll user")]
        public async Task GetAll()
        {
            var listUserDto = new List<UserDto>();
            var countList = 3;
            for (int i = 0; i < countList; i++)
            {
                listUserDto.Add(new UserDto
                {
                    Name = $"Any_Name{i}",
                    Id = Guid.NewGuid(),
                    Email = $"Any_Email{i}",
                    CreateAt = DateTime.UtcNow
                });
            }

            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(x => x.GetAll()).ReturnsAsync(listUserDto);

            _controller = new UsersController(serviceMock.Object);

            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as List<UserDto>;
            Assert.NotNull(resultValue);
            Assert.True(resultValue.Count() == countList);
            for (int i = 0; i < countList; i++)
            {
                Assert.Equal(resultValue[i].Name, listUserDto[i].Name);
                Assert.Equal(resultValue[i].Id, listUserDto[i].Id);
                Assert.Equal(resultValue[i].Email, listUserDto[i].Email);
                Assert.Equal(resultValue[i].CreateAt, listUserDto[i].CreateAt);
            }

            serviceMock.Setup(x => x.GetAll()).ReturnsAsync(new List<UserDto>());
            _controller = new UsersController(serviceMock.Object);

            var resultEmpty = await _controller.GetAll();
            Assert.True(resultEmpty is OkObjectResult);

            var resultEmptyValue = ((OkObjectResult)resultEmpty).Value as List<UserDto>;
            Assert.NotNull(resultEmptyValue);
            Assert.True(resultEmptyValue.Count() == 0);
        }
    }
}