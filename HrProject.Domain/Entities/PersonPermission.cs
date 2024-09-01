using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities;

public class PersonPermission : BaseEntity
{
    public int PersonId { get; set; }
    public virtual Person Person { get; set; } = default!;
    public int PersonPermissionTypeId { get; set; }
    public virtual PersonPermissionType? PersonPermissionType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime FinishDate { get; set; }
    public string? File { get; set; }
    public string? Description { get; set; }



}
