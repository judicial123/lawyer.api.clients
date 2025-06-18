using lawyer.api.clients.domain.Common;

namespace awyer.api.clients.application.Contracts.Interfases.Persistence.Common;

public interface ICommandRepository<T> where T : BaseEntity
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}