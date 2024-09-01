using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities;

public class PersonPermissionPayment : BaseEntity
{
    public int PersonId { get; set; }
    public virtual Person Person { get; set; }
    public int PaymentDay { get; set; }
    public int PaymentYear { get; set; }
    public decimal Price { get; set; }


}
