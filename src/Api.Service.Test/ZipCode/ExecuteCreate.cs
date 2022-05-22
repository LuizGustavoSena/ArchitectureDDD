using System.Threading.Tasks;
using Api.Domain.Interfaces.Service.ZipCode;
using Api.Service.Test.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class ExecuteCreate : ZipCodTests
    {
        private IZipCodeService _service;
        private Mock<IZipCodeService> _serviceMock;

        [Fact(DisplayName = "Should correct Create.")]
        public async Task Create()
        {
            _serviceMock = new Mock<IZipCodeService>();
            _serviceMock.Setup(m => m.Post(zipCodeDtoCreate)).ReturnsAsync(zipCodeDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(zipCodeDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(Code, result.Code);
            Assert.Equal(Street, result.Street);
            Assert.Equal(Number, result.Number);

        }
    }
}
