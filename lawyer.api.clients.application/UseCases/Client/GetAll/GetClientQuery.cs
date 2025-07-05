using lawyer.api.clients.application.DTO;
using MediatR;
// Asumí que tu DTO estará en esta carpeta

namespace lawyer.api.clients.application.UseCases.Client.Get;

public class GetClientsQuery : IRequest<List<ClientDto>>
{
    // Puede incluir filtros en el futuro si es necesario, como por ejemplo por país o estado
}