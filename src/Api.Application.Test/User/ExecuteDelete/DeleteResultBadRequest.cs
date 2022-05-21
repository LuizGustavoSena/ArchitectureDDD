using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Service.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.User.ExecuteDelete
{
    public class DeleteResultBadRequest
    {
        private UsersController _controllers;

        [Fact(DisplayName = "Should BadRequest result Delete")]
        public async Task Delete()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(x => x.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _controllers = new UsersController(serviceMock.Object);
            _controllers.ModelState.AddModelError("Id", "Campo obrigatório");

            var result = await _controllers.Delete(default(Guid));
            Assert.True(result is BadRequestObjectResult);
        }
    }
}