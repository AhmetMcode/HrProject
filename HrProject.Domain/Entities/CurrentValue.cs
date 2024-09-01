using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class CurrentValue : BaseEntity
    {
        public string CurrentValueName { get; set; }
        public decimal Price { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
    }
}
