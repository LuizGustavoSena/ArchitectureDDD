using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class StateImplementations : BaseRepository<StateEntity>, IStateRepository
    {
        private DbSet<StateEntity> _dataset;
        public StateImplementations(MyContext context) : base(context)
        {
            _dataset = context.Set<StateEntity>();
        }
    }
}