using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class ZipCodeImplementations : BaseRepository<ZipCodeEntity>, IZipCodeRepository
    {
        private DbSet<ZipCodeEntity> _dataset;
        public ZipCodeImplementations(MyContext context) : base(context)
        {
            _dataset = context.Set<ZipCodeEntity>();
        }

        public async Task<ZipCodeEntity> SelectAsync(int code)
        {
            return await _dataset.Include(x => x.City)
                                    .ThenInclude(x => x.State)
                                    .FirstOrDefaultAsync(x => x.Code.Equals(code));
        }
    }
}