namespace lawyer.api.clients.domain.Common;

public class BaseEntity
{
    public int Id { get; set; }

    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
}