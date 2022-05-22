using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.State;
using Api.Domain.Interfaces.Service.State;
using Moq;
using Xunit;

namespace Api.Service.Test.Uf
{
    public class ExecuteGetAll : StateTests
    {
        private IStateService _service;
        private Mock<IStateService> _serviceMock;

        [Fact(DisplayName = "Should correct result GETAll.")]
        public async Task GetAll()
        {
            _serviceMock = new Mock<IStateService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listaUfDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<StateDto>();

            _serviceMock = new Mock<IStateService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}
