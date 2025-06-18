using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using awyer.api.clients.application.Contracts.Interfases.Persistence.Common;
using lawyer.api.clients.datastore.mssql.DatabaseContext;
using lawyer.api.clients.datastore.mssql.Model.Common;
using lawyer.api.clients.domain.Common;

namespace lawyer.api.clients.datastore.mssql.Repositories.Common
{
    public class QueryRepository<T, TEntity> : IQueryRepository<T>
        where T : BaseEntity
        where TEntity : EFEntity
    {
        private readonly LawyersContext _dbContext;
        private readonly IMapper _mapper;

        public QueryRepository(LawyersContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<T> GetByIdAsync(int id, params string[] includes)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var entity = await query.FirstOrDefaultAsync(e => e.Id == id);

            return entity == null ? null : _mapper.Map<T>(entity);
        }

        public async Task<List<T>> GetAsync(params string[] includes)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var entities = await query.ToListAsync();
            return _mapper.Map<List<T>>(entities);
        }
    }
}