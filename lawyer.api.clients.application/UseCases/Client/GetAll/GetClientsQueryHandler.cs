using lawyer.api.clients.application.DTO;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using lawyer.api.clients.application.Contracts.Interfases.Persistence;

namespace lawyer.api.clients.application.UseCases.Client.Get
{
    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, List<ClientDto>>
    {
        private readonly IMapper _mapper;
        private readonly IClientQueryRepository _clientRepository;

        public GetClientsQueryHandler(IMapper mapper, IClientQueryRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<List<ClientDto>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            // Consultar la base de datos
            List<lawyer.api.domain.Client> clients = await _clientRepository.GetAsync();
            
            // Mapear entidades a DTOs
            var data = _mapper.Map<List<ClientDto>>(clients);
            
            // Retornar la lista de DTOs
            return data;
        }
    }
}