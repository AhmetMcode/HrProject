using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class OfferTerminSub : BaseEntity
    {
        public Offer Offer { get; set; }
        public int OfferId { get; set; }
        public string? Desc { get; set; }
        public string? AnsWer { get; set; }
        public bool send { get; set; }
        public TerminType TerminType { get; set; }
        public List<OfferTerminDetail> OfferTerminDetails { get; set; }

    }
    public class OfferTerminDetail : BaseEntity
    {
        public int OfferTerminSubId { get; set; }
        public OfferTerminSub OfferTerminSub { get; set; }
        public ProjectElementType ProjectElementType { get; set; }
        public int ProjectElementTypeId { get; set; }
        public int Length { get; set; }
        public int QuanTity { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string? BetonSinif { get; set; }
        public string? CalculatePozNumber { get; set; }
    }
}
