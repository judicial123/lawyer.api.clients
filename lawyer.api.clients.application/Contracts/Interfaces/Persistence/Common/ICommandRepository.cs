using lawyer.api.clients.domain.Common;

namespace lawyer.api.clients.application.Contracts.Interfaces.Persistence.Common;

public interface ICommandRepository<T> where T : BaseEntity
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}