using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class ProductionPlace : BaseEntity
    {
        public string Name { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public decimal Height { get; set; }

    }
}
