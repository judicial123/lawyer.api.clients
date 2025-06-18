using lawyer.api.clients.domain.Common;

namespace lawyer.api.domain
{
    public class Client : BaseEntity
    {
        public string PhoneNumber { get; set; } = string.Empty; // Client's phone number

        public string IdentityDocument { get; set; } = string.Empty; // Client's ID/DNI/passport number

        public DateTime? BirthDate { get; set; } // Client's birth date

        public string MaritalStatus { get; set; } = string.Empty; // Client's marital status (Single, Married, etc.)

        public string PhotoUrl { get; set; } = string.Empty; // URL of the profile photo

        public string Notes { get; set; } = string.Empty; // Additional comments or information about the client
    }
}