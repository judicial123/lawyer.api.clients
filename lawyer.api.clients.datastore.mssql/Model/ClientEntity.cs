using System.ComponentModel.DataAnnotations.Schema;
using lawyer.api.clients.datastore.mssql.Model.Common;

namespace lawyer.api.clients.datastore.mssql.Model;

[Table("Clients")]
public class ClientEntity : EFEntity
{
    public string PhoneNumber { get; set; } // Client's phone number

    public string IdentityDocument { get; set; } // Client's ID/DNI/passport number

    public DateTime? BirthDate { get; set; } // Client's birth date

    public string MaritalStatus { get; set; } // Client's marital status (Single, Married, etc.)

    public string PhotoUrl { get; set; } // URL of the profile photo

    [Column(TypeName = "TEXT")] public string Notes { get; set; } // Additional comments or information about the client
}