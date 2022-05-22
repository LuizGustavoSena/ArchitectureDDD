using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.State;
using Api.Domain.Interfaces.Service.State;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Service
{
    public class StateService : IStateService
    {
        private IStateRepository _repository;
        private IMapper _mapper;

        public StateService(IStateRepository repository,
                            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<StateDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<StateDto>(entity);
        }

        public async Task<IEnumerable<StateDto>> GetAll()
        {
            var entitys = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<StateDto>>(entitys);
        }
    }
}