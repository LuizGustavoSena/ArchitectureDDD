using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.ZipCode;
using Api.Domain.Interfaces.Service.ZipCode;
using Api.Service.Test.Municipio;
using Moq;
using Xunit;

namespace Api.Service.Test.Cep
{
    public class ExecuteGet : ZipCodTests
    {
        private IZipCodeService _service;
        private Mock<IZipCodeService> _serviceMock;

        [Fact(DisplayName = "É Possivel Executar o Método GET.")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IZipCodeService>();
            _serviceMock.Setup(m => m.Get(CityId)).ReturnsAsync(zipCodeDto);
            _service = _serviceMock.Object;

            var result = await _service.Get(CityId);
            Assert.NotNull(result);
            Assert.True(result.Id == CodeId);
            Assert.Equal(Code, result.Code);
            Assert.Equal(Street, result.Street);

            _serviceMock = new Mock<IZipCodeService>();
            _serviceMock.Setup(m => m.Get(Code)).ReturnsAsync(zipCodeDto);
            _service = _serviceMock.Object;

            result = await _service.Get(Code);
            Assert.NotNull(result);
            Assert.True(result.Id == CodeId);
            Assert.Equal(Code, result.Code);
            Assert.Equal(Street, result.Street);

            _serviceMock = new Mock<IZipCodeService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((ZipCodeDto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(Guid.NewGuid());
            Assert.Null(_record);
        }
    }
}
