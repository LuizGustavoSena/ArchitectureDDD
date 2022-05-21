using System;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Service.User;
using Moq;
using Xunit;

namespace Api.Service.Test.Login
{
    public class ExecuteFindByLogin
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "Should correct FindByEmail")]
        public async Task FindByEmail()
        {
            var email = "Any_Email";
            var resultObject = new
            {
                authenticated = true,
                created = DateTime.UtcNow,
                expiration = DateTime.UtcNow.AddHours(8),
                accessToken = "Any_AccessToken",
                user = new
                {
                    name = "Any_Name",
                    Email = email
                },
                message = "Usuário logado",
            };
            var loginDto = new LoginDto
            {
                Email = email
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(x => x.FindByLogin(loginDto)).ReturnsAsync(resultObject);
            _service = _serviceMock.Object;

            var result = await _service.FindByLogin(loginDto);
            Assert.NotNull(result);
        }
    }
}