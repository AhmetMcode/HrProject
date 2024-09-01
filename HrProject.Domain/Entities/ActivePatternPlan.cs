using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class ActivePatternPlan : BaseEntity
    {
        public int PatternId { get; set; }
        public Pattern Pattern { get; set; }
        public int ProductionPlaceId { get; set; }
        public ProductionPlace ProductionPlace { get; set; }
        public decimal Top { get; set; }
        public decimal Left { get; set; }
    }

}
