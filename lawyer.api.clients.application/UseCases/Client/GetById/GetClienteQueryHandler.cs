using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using lawyer.api.domain;
using lawyer.api.clients.application.Contracts.Interfases.Persistence;
using lawyer.api.clients.application.DTO;

namespace lawyer.api.clients.application.UseCases.Client.Get
{
    public class GetClientQueryHandler : IRequestHandler<GetClientQuery, ClientDto>
    {
        private readonly IMapper _mapper;
        private readonly IClientQueryRepository _clientRepository;

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
}
