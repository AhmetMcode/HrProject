using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class FirstOffer : BaseEntity
    {
        public int SubFirstOfferId { get; set; }
        public SubFirstOffer SubFirstOffer { get; set; }
        public int GoodsCodeId { get; set; }
        public GoodsCode GoodsCode { get; set; }
        public string StockNames { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal Quantity { get; set; }
        public string? UnitType { get; set; }
        public string? Description { get; set; }
    }
}
