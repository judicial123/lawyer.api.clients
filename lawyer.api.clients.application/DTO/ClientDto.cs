namespace lawyer.api.clients.application.DTO
{
    public class ClientDto
    {
        public int Id { get; set; }

        public string PhoneNumber { get; set; } = string.Empty; // Client's phone number

        public string IdentityDocument { get; set; } = string.Empty; // Client's ID/DNI/passport

        public DateTime? BirthDate { get; set; } // Client's birth date

        public string MaritalStatus { get; set; } = string.Empty; // Client's marital status

        public string PhotoUrl { get; set; } = string.Empty; // Profile photo URL

        public string Notes { get; set; } = string.Empty; // Additional notes
    }
}