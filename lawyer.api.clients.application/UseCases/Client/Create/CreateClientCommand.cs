using MediatR;

namespace lawyer.api.clients.application.UseCases.Client.Create;

public class CreateClientCommand : IRequest<int>
{
    public string PhoneNumber { get; set; } = string.Empty; // Client's phone number

    public string IdentityDocument { get; set; } = string.Empty; // Client's ID/DNI/passport

    public DateTime? BirthDate { get; set; } // Client's birth date (nullable)

    public string MaritalStatus { get; set; } = string.Empty; // Client's marital status

    public string PhotoUrl { get; set; } = string.Empty; // Profile photo URL

    public string Notes { get; set; } = string.Empty; // Additional notes
}