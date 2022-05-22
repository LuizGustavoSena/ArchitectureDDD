using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.ZipCode;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Service.ZipCode;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Service
{
    public class ZipCodeService : IZipCodeService
    {
        private IZipCodeRepository _repository;
        private IMapper _mapper;

        public ZipCodeService(IZipCodeRepository repository,
                                IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ZipCodeDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<ZipCodeDto>(entity);
        }

        public async Task<ZipCodeDto> Get(int cep)
        {
            var entity = await _repository.SelectAsync(cep);
            return _mapper.Map<ZipCodeDto>(entity);
        }

        public async Task<ZipCodeDtoCreateResult> Post(ZipCodeDtoCreate cep)
        {
            var model = _mapper.Map<ZipCodeModel>(cep);
            var entity = _mapper.Map<ZipCodeEntity>(cep);

            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<ZipCodeDtoCreateResult>(result);
        }

        public async Task<ZipCodeDtoUpdateResult> Put(ZipCodeDtoUpdate cep)
        {
            var model = _mapper.Map<ZipCodeModel>(cep);
            var entity = _mapper.Map<ZipCodeEntity>(cep);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<ZipCodeDtoUpdateResult>(result);
        }
    }
}