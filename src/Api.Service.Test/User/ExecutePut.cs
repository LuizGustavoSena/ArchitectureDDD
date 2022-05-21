using System.Threading.Tasks;
using Api.Domain.Interfaces.Service.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class ExecutePut : UserTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Should Correct Put")]
        public async Task Put()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(x => x.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(userDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(UserName, result.Name);
            Assert.Equal(UserEmail, result.Email);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(x => x.Put(userDtoUpdate)).ReturnsAsync(userDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultPut = await _service.Put(userDtoUpdate);
            Assert.NotNull(resultPut);
            Assert.Equal(UserNameAltered, resultPut.Name);
            Assert.Equal(UserEmailAltered, resultPut.Email);
        }
    }
}