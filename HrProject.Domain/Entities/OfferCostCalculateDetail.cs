using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class OfferCostCalculateDetail : BaseEntity
    {
        public int OfferPartId { get; set; }
        public OfferPart OfferPart { get; set; }
        public int OfferMaterialsId { get; set; }
        public OfferMaterials OfferMaterials { get; set; }
        public decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal Percent { get; set; }
        public decimal Enflasyon { get; set; }
        public decimal CurrentValueC { get; set; }
        public int Wastage { get; set; }
    }
}
