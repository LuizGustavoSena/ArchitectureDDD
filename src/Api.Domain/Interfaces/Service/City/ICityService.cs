using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.City;

namespace Api.Domain.Interfaces.Service.City
{
    public interface ICityService
    {
        Task<CityDto> Get(Guid id);
        Task<CityDtoComplete> GetCompleteById(Guid id);
        Task<CityDtoComplete> GetCompleteByCode(int code);
        Task<IEnumerable<CityDto>> GetAll();
        Task<CityDtoCreateResult> Post(CityDtoCreate city);
        Task<CityDtoUpdateResult> Put(CityDtoUpdate city);
        Task<bool> Delete(Guid id);
    }
}