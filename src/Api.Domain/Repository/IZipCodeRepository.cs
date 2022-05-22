using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IZipCodeRepository : IRepository<ZipCodeEntity>
    {
        Task<ZipCodeEntity> SelectAsync(int code);
    }
}