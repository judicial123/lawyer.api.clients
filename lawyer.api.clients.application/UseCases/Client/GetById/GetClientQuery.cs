using lawyer.api.clients.application.DTO;
using MediatR;

namespace lawyer.api.clients.application.UseCases.Client.Get
{
    public class GetClientQuery : IRequest<ClientDto>
    {
        public int Id { get; set; }

        public GetClientQuery(int id)
        {
            Id = id;
        }
    }
}