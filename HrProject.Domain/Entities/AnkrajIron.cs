using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class AnkrajIron : BaseEntity
    {

        public int OfferCalculateId { get; set; }
        public OfferCalculate OfferCalculate { get; set; }
        public int Price { get; set; }

        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Weight { get; set; }
        public decimal Thick { get; set; }
    }
    public class PmAnkrajIron : BaseEntity
    {

        public int PmCalculateId { get; set; }
        public PmCalculate PmCalculate { get; set; }
        public int Price { get; set; }

        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Weight { get; set; }
        public decimal Thick { get; set; }
    }
}
