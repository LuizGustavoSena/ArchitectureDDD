using System;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Service.ZipCode;
using Api.Service.Test.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class ExecuteDelete : ZipCodTests
    {
        private IZipCodeService _service;
        private Mock<IZipCodeService> _serviceMock;
        [Fact(DisplayName = "Should correct Delete.")]
        public async Task Delete()
        {
            _serviceMock = new Mock<IZipCodeService>();
            _serviceMock.Setup(m => m.Delete(CityId))
                        .ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(CityId);
            Assert.True(deletado);

            _serviceMock = new Mock<IZipCodeService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>()))
                        .ReturnsAsync(false);
            _service = _serviceMock.Object;

            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);
        }
    }
}
