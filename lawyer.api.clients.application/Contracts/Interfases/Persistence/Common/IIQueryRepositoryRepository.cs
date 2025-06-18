using lawyer.api.clients.domain.Common;

namespace awyer.api.clients.application.Contracts.Interfases.Persistence.Common;

public interface IQueryRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id,params string[] includes);
    Task<List<T>> GetAsync(params string[] includes);
}