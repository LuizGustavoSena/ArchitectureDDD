using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Service.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.ExecutePost
{
    public class CreatedResultBadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "Should sucess created user")]
        public async Task SucessPost()
        {
            var userDtoCreate = new UserDtoCreate
            {
                Email = "Any_Email",
                Name = "Any_Name"
            };

            var UserDtoCreateResult = new UserDtoCreateResult
            {
                CreateAt = DateTime.UtcNow,
                Email = userDtoCreate.Email,
                Id = Guid.NewGuid(),
                Name = userDtoCreate.Name
            };

            var serviceMock = new Mock<IUserService>();
            var url = new Mock<IUrlHelper>();

            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            serviceMock.Setup(x => x.Post(userDtoCreate)).Returns(Task.FromResult(UserDtoCreateResult));

            _controller = new UsersController(serviceMock.Object);
            _controller.Url = url.Object;
            _controller.ModelState.AddModelError("Name", "Campo obrigatório");

            var result = await _controller.Post(userDtoCreate);
            Assert.True(result is BadRequestObjectResult);

        }
    }
}