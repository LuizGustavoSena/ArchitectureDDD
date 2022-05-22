using System.Threading.Tasks;
using Api.Domain.Interfaces.Service.City;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class ExecuteGetCompleteByIBGE : CityTests
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "Should correct GET Complete By IBGE.")]
        public async Task Get_Complete_by_IBGE()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.GetCompleteByCode(CityCode)).ReturnsAsync(cityDtoComplete);
            _service = _serviceMock.Object;

            var result = await _service.GetCompleteByCode(CityCode);
            Assert.NotNull(result);
            Assert.True(result.Id == CityId);
            Assert.Equal(CityName, result.Name);
            Assert.Equal(CityCode, result.Cod);
            Assert.NotNull(result.State);
        }
    }
}
