using System;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class CityImplementations : BaseRepository<CityEntity>, ICityRepository
    {
        private DbSet<CityEntity> _dataset;
        public CityImplementations(MyContext context) : base(context)
        {
            _dataset = context.Set<CityEntity>();
        }

        public async Task<CityEntity> GetCompleteByCode(int code)
        {
            return await _dataset.Include(x => x.State)
                            .FirstOrDefaultAsync(x => x.Cod.Equals(code));
        }

        public async Task<CityEntity> GetCompleteById(Guid id)
        {
            return await _dataset.Include(x => x.State)
                            .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}