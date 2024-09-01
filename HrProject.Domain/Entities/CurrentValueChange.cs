using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class CurrentValueChange : BaseEntity
    {
        public bool IsActive { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CurrentValueId { get; set; }
        public CurrentValue CurrentValue { get; set; }

    }
}
