using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using lawyer.api.clients.application.Contracts.Interfases.Persistence;

namespace lawyer.api.clients.application.UseCases.Client.Update
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Unit>
    {
        private readonly IClientCommandRepository _clientRepository;
        private readonly IClientQueryRepository _clientQueryRepository;

        public UpdateClientCommandHandler(
            IClientCommandRepository clientRepository,
            IClientQueryRepository clientQueryRepository)
        {
            _clientRepository = clientRepository;
            _clientQueryRepository = clientQueryRepository;
        }

        public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            // Verificar si el cliente existe
            var existingClient = await _clientQueryRepository.GetByIdAsync(request.Id);
            if (existingClient == null)
            {
                throw new KeyNotFoundException($"The client with ID {request.Id} does not exist.");
            }

            // Actualizar campos permitidos
            existingClient.PhotoUrl = request.PhotoUrl;
            existingClient.PhoneNumber = request.PhoneNumber;
            existingClient.MaritalStatus = request.MaritalStatus;

            // Guardar cambios
            await _clientRepository.UpdateAsync(existingClient);

            return Unit.Value;
        }
    }
}