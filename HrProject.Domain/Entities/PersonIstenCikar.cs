using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities;

public class PersonIstenCikar : BaseEntity
{
    public int PersonId { get; set; }
    public virtual Person Person { get; set; } = default!;
    public DateTime RemoveDate { get; set; }
    public decimal? IhbarTazminati { get; set; }
    public decimal? KidemTazminati { get; set; }
    public string? File { get; set; }
    public string? Description { get; set; }


}

