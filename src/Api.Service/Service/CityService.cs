using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.City;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Service.City;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Service
{
    public class CityService : ICityService
    {
        private ICityRepository _repository;
        private IMapper _mapper;

        public CityService(ICityRepository repository,
                            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<CityDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<CityDto>(entity);
        }

        public Task<IEnumerable<CityDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<CityDtoComplete> GetCompleteByCode(int code)
        {
            var entity = await _repository.GetCompleteByCode(code);
            return _mapper.Map<CityDtoComplete>(entity);
        }

        public async Task<CityDtoComplete> GetCompleteById(Guid id)
        {
            var entity = await _repository.GetCompleteById(id);
            return _mapper.Map<CityDtoComplete>(entity);
        }

        public async Task<CityDtoCreateResult> Post(CityDtoCreate city)
        {
            var model = _mapper.Map<CityModel>(city);
            var entityRequest = _mapper.Map<CityEntity>(model);

            var entity = await _repository.InsertAsync(entityRequest);
            return _mapper.Map<CityDtoCreateResult>(entity);
        }

        public async Task<CityDtoUpdateResult> Put(CityDtoUpdate city)
        {
            var model = _mapper.Map<CityModel>(city);
            var entityRequest = _mapper.Map<CityEntity>(model);

            var entity = await _repository.UpdateAsync(entityRequest);
            return _mapper.Map<CityDtoUpdateResult>(entity);
        }
    }
}