using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities;

public class PersonPermissionType : BaseEntity
{
    public string Name { get; set; }
    public int NumberOfDays { get; set; }
    public bool IsPaid { get; set; }

    public virtual ICollection<PersonPermission> PersonPermissions { get; set; }
}
