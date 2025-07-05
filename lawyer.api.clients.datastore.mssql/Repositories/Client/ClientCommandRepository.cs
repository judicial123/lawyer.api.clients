using AutoMapper;
using lawyer.api.clients.application.Contracts.Interfaces.Persistence.Client;
using lawyer.api.clients.datastore.mssql.DatabaseContext;
using lawyer.api.clients.datastore.mssql.Model;
using lawyer.api.clients.datastore.mssql.Repositories.Common;

namespace lawyer.api.clients.datastore.mssql.Repositories.Client;

public class ClientCommandRepository : CommandRepository<domain.Client, ClientEntity>, IClientCommandRepository
{
    private readonly IMapper _mapper;

    public ClientCommandRepository(LawyersContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper;
    }
}