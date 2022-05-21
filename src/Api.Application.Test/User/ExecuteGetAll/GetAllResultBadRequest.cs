using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Service.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.ExecuteGetAll
{
    public class GetAllResultBadRequest
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
            _controller.ModelState.AddModelError("Id", "Campo obrigatório");

            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}