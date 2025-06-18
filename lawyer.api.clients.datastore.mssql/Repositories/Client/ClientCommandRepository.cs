using AutoMapper;
using lawyer.api.clients.application.Contracts.Interfases.Persistence;
using lawyer.api.clients.datastore.mssql.DatabaseContext;
using lawyer.api.clients.datastore.mssql.Model;
using lawyer.api.clients.datastore.mssql.Repositories.Common;
using lawyer.api.domain;

namespace lawyer.api.clients.datastore.mssql.Repositories;

public class ClientCommandRepository : CommandRepository<Client, ClientEntity>, IClientCommandRepository
{
    private readonly IMapper _mapper;

    public ClientCommandRepository(LawyersContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
        _mapper = mapper;
    }
}