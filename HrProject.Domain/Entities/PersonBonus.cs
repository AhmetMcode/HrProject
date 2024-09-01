using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities;

public class PersonBonus : BaseEntity
{
    public decimal BonusAmount { get; set; }
    public DateTime DateOfIssue { get; set; }
    public string Description { get; set; }
    public bool IsOkey { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
}
