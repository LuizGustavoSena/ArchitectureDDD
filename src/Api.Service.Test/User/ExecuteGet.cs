using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Service.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class ExecuteGet : UserTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Should currect GET")]
        public async Task Get()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(x => x.Get(UserId)).ReturnsAsync(userDto);
            _service = _serviceMock.Object;

            var resultGet = await _service.Get(UserId);
            Assert.NotNull(resultGet);
            Assert.Equal(UserId, resultGet.Id);
            Assert.Equal(UserName, resultGet.Name);
            Assert.Equal(UserEmail, resultGet.Email);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto)null));
            _service = _serviceMock.Object;

            var resultGetNull = await _service.Get(UserId);
            Assert.Null(resultGetNull);
        }
    }
}