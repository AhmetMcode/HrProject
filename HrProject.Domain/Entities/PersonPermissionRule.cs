using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities;

public class PersonPermissionRule : BaseEntity
{
    public int WorkingYear { get; set; }
    public int Day { get; set; }
    public bool IsRetired { get; set; }
}
