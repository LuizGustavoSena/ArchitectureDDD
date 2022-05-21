using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Service.User;
using Moq;
using Xunit;

namespace Api.Service.Test.User
{
    public class ExecuteGetAll : UserTest
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Should currect GetAll")]
        public async Task GetAll()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(x => x.GetAll()).ReturnsAsync(ListUserDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(x => x.GetAll()).ReturnsAsync(new List<UserDto>().AsEnumerable);
            _service = _serviceMock.Object;

            var resultEmpty = await _service.GetAll();
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}