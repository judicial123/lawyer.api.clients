using lawyer.api.clients.application.Contracts.Interfaces.Persistence.Common;

namespace lawyer.api.clients.application.Contracts.Interfaces.Persistence.Client;

public interface IClientQueryRepository : IQueryRepository<domain.Client>
{
}