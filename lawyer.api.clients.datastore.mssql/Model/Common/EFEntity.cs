using System.ComponentModel.DataAnnotations.Schema;

namespace lawyer.api.clients.datastore.mssql.Model.Common;

public class EFEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    

    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
}