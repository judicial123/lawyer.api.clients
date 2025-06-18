using lawyer.api.clients.application.DTO; // Asumí que tu DTO estará en esta carpeta
using MediatR;
using System.Collections.Generic;

namespace lawyer.api.clients.application.UseCases.Client.Get
{
    public class GetClientsQuery : IRequest<List<ClientDto>>
    {
        // Puede incluir filtros en el futuro si es necesario, como por ejemplo por país o estado
    }
}