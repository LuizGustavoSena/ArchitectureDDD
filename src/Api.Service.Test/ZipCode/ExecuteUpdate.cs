using System.Threading.Tasks;
using Api.Domain.Interfaces.Service.ZipCode;
using Api.Service.Test.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class ExecuteUpdate : ZipCodTests
    {
        private IZipCodeService _service;
        private Mock<IZipCodeService> _serviceMock;

        [Fact(DisplayName = "Should correct Update.")]
        public async Task Update()
        {
            _serviceMock = new Mock<IZipCodeService>();
            _serviceMock.Setup(m => m.Put(zipCodeDtoUpdate)).ReturnsAsync(zipCodeDtoUpdateResult);
            _service = _serviceMock.Object;

            var resultUpdate = await _service.Put(zipCodeDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(CodeAltered, resultUpdate.Code);
            Assert.Equal(StreetAltered, resultUpdate.Street);
            Assert.Equal(NumberAltered, resultUpdate.Number);

        }
    }
}
