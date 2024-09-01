using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class OfferPart : BaseEntity
    {
        public string? PartName { get; set; }
        public string? DescByPrint { get; set; }
        public decimal ProfitRate { get; set; }
        public decimal ProfitTotal { get; set; }
        public decimal SozlesmeTutari { get; set; }
        public decimal TotalFee { get; set; }
        public decimal Cost { get; set; }
        public decimal Miktar { get; set; }
        public decimal MetreKare { get; set; }
        public decimal VkAdet { get; set; }
        public decimal CpMetreKare { get; set; }
        public decimal StandartTir { get; set; }
        public decimal StandartTirAdet { get; set; }
        public decimal DollyDorse { get; set; }
        public decimal DollyDorseAdet { get; set; }
        public decimal Demir { get; set; }
        public decimal Beton { get; set; }
        public decimal Halat { get; set; }
        public decimal Hasir { get; set; }
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
        public List<OfferCalculate> OfferCalculates { get; set; }
    }
}
