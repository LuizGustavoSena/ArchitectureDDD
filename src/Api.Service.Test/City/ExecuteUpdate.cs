using System.Threading.Tasks;
using Api.Domain.Interfaces.Service.City;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class ExecuteUpdate : CityTests
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "Should correct Update.")]
        public async Task Update()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.Put(cityDtoUpdate)).ReturnsAsync(cityDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(cityDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(CityNameAltered, resultUpdate.Name);
            Assert.Equal(CityCodeAltered, resultUpdate.Cod);
            Assert.Equal(StateId, resultUpdate.StateId);

        }
    }
}
