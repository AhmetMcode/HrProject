using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities;

public class PersonPermissionTransfer : BaseEntity
{
    public int TransferYear { get; set; }
    public int TransferedYear { get; set; }
    public int TransferDay { get; set; }
    public int PersonId { get; set; }
    public virtual Person Person { get; set; }
}
