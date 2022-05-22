using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.City;
using Api.Domain.Interfaces.Service.City;
using Moq;
using Xunit;

namespace Api.Service.Test.Municipio
{
    public class ExecutedoGet : CityTests
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "Should correct GET.")]
        public async Task GET()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.Get(CityId)).ReturnsAsync(cityDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(CityId);
            Assert.NotNull(result);
            Assert.True(result.Id == CityId);
            Assert.Equal(CityName, result.Name);
            Assert.Equal(CityCode, result.Cod);

            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CityDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(Guid.NewGuid());
            Assert.Null(_record);
        }
    }
}
