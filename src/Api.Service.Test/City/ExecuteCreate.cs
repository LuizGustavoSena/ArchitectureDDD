using System.Threading.Tasks;
using Api.Domain.Interfaces.Service.City;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class ExecuteCreate : CityTests
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "Should correct Create.")]
        public async Task Create()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.Post(cityDtoCreate)).ReturnsAsync(cityDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(cityDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(CityName, result.Name);
            Assert.Equal(CityCode, result.Cod);
            Assert.Equal(StateId, result.StateId);
        }
    }
}
