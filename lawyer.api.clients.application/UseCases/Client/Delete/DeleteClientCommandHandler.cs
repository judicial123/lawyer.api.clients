using lawyer.api.clients.application.Contracts.Interfases.Persistence;
using lawyer.api.clients.application.UseCases.Client.Delete;
using MediatR;

namespace awyer.api.clients.application.UseCases.Client.Delete;

public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Unit>
{
    private readonly IClientCommandRepository _clienteRepository;
    private readonly IClientQueryRepository _clienteQueryRepository;

    public DeleteClientCommandHandler(IClientCommandRepository clienteRepository, IClientQueryRepository clienteQueryRepository)
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