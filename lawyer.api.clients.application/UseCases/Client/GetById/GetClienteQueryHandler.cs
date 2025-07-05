using AutoMapper;
using lawyer.api.clients.application.Contracts.Interfaces.Persistence.Client;
using lawyer.api.clients.application.DTO;
using MediatR;

namespace lawyer.api.clients.application.UseCases.Client.Get;

public class GetClientQueryHandler : IRequestHandler<GetClientQuery, ClientDto>
{
    private readonly IClientQueryRepository _clientRepository;
    private readonly IMapper _mapper;

    public GetClientQueryHandler(
        IMapper mapper,
        IClientQueryRepository clientRepository)
    {
        _mapper = mapper;
        _clientRepository = clientRepository;
    }

    public async Task<ClientDto> Handle(GetClientQuery request, CancellationToken cancellationToken)
    {
        // Obtener el cliente
        var client = await _clientRepository.GetByIdAsync(request.Id);
        //if (client == null)
        //{
        //    throw new NotFoundException(nameof(Client), request.Id);
        //}

        var data = _mapper.Map<ClientDto>(client);
        return data;
    }
}