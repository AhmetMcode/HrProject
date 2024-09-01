using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class SalesBaseOffer : BaseEntity
    {
        public int SalesOfferId { get; set; }
        public SalesOffer SalesOffer { get; set; }
        public List<SalesDetailOffer> SalesDetailOffers { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal GeneralVATTotal { get; set; }
        public decimal GeneralTotal { get; set; }
    }
}
