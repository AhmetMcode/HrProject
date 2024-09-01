using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class SalesOffer : BaseEntity
    {
        public int CariKartId { get; set; }
        public CariKart CariKart { get; set; }
        public string Name { get; set; }
        public DateTime TermDate { get; set; }
        public string? Document { get; set; }
        public string? Description { get; set; }
        public List<SalesDetailOffer> SalesDetailOffers { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? GeneralVATTotal { get; set; }
        public decimal? GeneralTotal { get; set; }

        public SalesOfferProcess? SalesOfferProcess { get; set; }

    }
}
