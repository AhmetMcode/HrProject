using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class PersonSalary : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }


    }
}
