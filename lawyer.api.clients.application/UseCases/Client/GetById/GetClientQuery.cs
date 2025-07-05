using lawyer.api.clients.application.DTO;
using MediatR;

namespace lawyer.api.clients.application.UseCases.Client.Get;

public class GetClientQuery : IRequest<ClientDto>
{
    public GetClientQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}