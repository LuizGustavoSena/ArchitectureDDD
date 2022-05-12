using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class UserImplementations : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dbset;

        public UserImplementations(MyContext context) : base(context)
        {
            _dbset = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByEmal(string email)
        {
            return await _dbset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}