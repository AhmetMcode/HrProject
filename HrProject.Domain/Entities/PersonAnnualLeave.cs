using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities;

public class PersonAnnualLeave : BaseEntity
{
    public int PersonId { get; set; }
    public virtual Person Person { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime FinishDate { get; set; }
    public int UsedDay { get; set; }
    public string? Description { get; set; }
    public DateTime ReturnDate { get; set; }

}
