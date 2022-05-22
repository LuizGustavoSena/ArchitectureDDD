using System;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface ICityRepository : IRepository<CityEntity>
    {
        Task<CityEntity> GetCompleteById(Guid id);
        Task<CityEntity> GetCompleteByCode(int code);
    }
}