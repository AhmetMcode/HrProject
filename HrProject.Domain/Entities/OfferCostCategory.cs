using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class OfferCostCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public List<OfferMaterials> OfferMaterials { get; set; }
    }
}
