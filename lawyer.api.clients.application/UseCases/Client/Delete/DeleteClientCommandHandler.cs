using lawyer.api.clients.application.Contracts.Interfaces.Persistence.Client;
using MediatR;

namespace lawyer.api.clients.application.UseCases.Client.Delete;

public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Unit>
{
    private readonly IClientQueryRepository _clienteQueryRepository;
    private readonly IClientCommandRepository _clienteRepository;

    public DeleteClientCommandHandler(IClientCommandRepository clienteRepository,
        IClientQueryRepository clienteQueryRepository)
    {
        _clienteRepository = clienteRepository;
        _clienteQueryRepository = clienteQueryRepository;
    }

    public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var clienteToDelete = await _clienteQueryRepository.GetByIdAsync(request.Id);

        //if (clienteToDelete == null)
        //    throw new NotFoundException(nameof(Client), request.Id);

        await _clienteRepository.DeleteAsync(clienteToDelete);

        return Unit.Value;
    }
}