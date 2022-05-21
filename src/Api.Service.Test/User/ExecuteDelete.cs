using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Service.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class ExecuteDelete : UserTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Should Correct Delete")]
        public async Task Delete()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(x => x.Delete(UserId)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var result = await _service.Delete(UserId);
            Assert.True(result);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(x => x.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            var resultFailed = await _service.Delete(Guid.NewGuid());
            Assert.False(resultFailed);
        }
    }
}