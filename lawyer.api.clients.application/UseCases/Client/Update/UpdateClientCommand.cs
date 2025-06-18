using MediatR;

namespace lawyer.api.clients.application.UseCases.Client.Update
{
    public class UpdateClientCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; } = string.Empty; // URL of the profile photo
        
        public string PhoneNumber { get; set; } = string.Empty; // WhatsApp number
        public string MaritalStatus { get; set; } = string.Empty; // Client's marital status
    }
}