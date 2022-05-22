using System.Threading.Tasks;
using Api.Domain.Interfaces.Service.City;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class ExecuteGetCompleteById : CityTests
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "Should correct GET Complete By Id.")]
        public async Task Get_Complete_by_Id()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.GetCompleteById(CityId)).ReturnsAsync(cityDtoComplete);
            _service = _serviceMock.Object;

            var result = await _service.GetCompleteById(CityId);
            Assert.NotNull(result);
            Assert.True(result.Id == CityId);
            Assert.Equal(CityName, result.Name);
            Assert.Equal(CityCode, result.Cod);
            Assert.NotNull(result.State);
        }
    }
}
