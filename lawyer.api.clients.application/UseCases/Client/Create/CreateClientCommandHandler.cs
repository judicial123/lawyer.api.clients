using AutoMapper;
using MediatR;
using lawyer.api.domain;
using System.Threading;
using System.Threading.Tasks;
using lawyer.api.clients.application.Contracts.Interfases.Persistence;
using lawyer.api.clients.application.UseCases.Client.Create;

namespace awyer.api.clients.application.UseCases.Client.Create
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
    {
        private readonly IClientCommandRepository _clienteRepository;
        private readonly IMapper _mapper;

        public CreateClientCommandHandler(
            IClientCommandRepository clienteRepository,
            IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            
            
            // Mapear y guardar el cliente en la base de datos
            var cliente = _mapper.Map<lawyer.api.domain.Client>(request);
            await _clienteRepository.CreateAsync(cliente);

            return cliente.Id;
        }
    }
}