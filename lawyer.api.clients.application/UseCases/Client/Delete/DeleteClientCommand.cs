using MediatR;

namespace lawyer.api.clients.application.UseCases.Client.Delete;

public class DeleteClientCommand: IRequest<Unit>
{
    public int Id { get; set; }
}