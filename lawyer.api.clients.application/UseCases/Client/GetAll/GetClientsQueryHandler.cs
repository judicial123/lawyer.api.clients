using AutoMapper;
using lawyer.api.clients.application.Contracts.Interfaces.Persistence.Client;
using lawyer.api.clients.application.DTO;
using MediatR;

namespace lawyer.api.clients.application.UseCases.Client.Get;

public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, List<ClientDto>>
{
    private readonly IClientQueryRepository _clientRepository;
    private readonly IMapper _mapper;

    public GetClientsQueryHandler(IMapper mapper, IClientQueryRepository clientRepository)
    {
        _mapper = mapper;
        _clientRepository = clientRepository;
    }

    public async Task<List<ClientDto>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        // Consultar la base de datos
        var clients = await _clientRepository.GetAsync();

        // Mapear entidades a DTOs
        var data = _mapper.Map<List<ClientDto>>(clients);

        // Retornar la lista de DTOs
        return data;
    }
}