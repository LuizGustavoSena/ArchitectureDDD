using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.ZipCode;

namespace Api.Domain.Interfaces.Service.ZipCode
{
    public interface IZipCodeService
    {
        Task<ZipCodeDto> Get(Guid id);
        Task<ZipCodeDto> Get(string cep);
        Task<ZipCodeDtoCreateResult> Post(ZipCodeDtoCreate cep);
        Task<ZipCodeDtoUpdateResult> Put(ZipCodeDtoUpdate cep);
        Task<bool> Delete(Guid id);
    }
}