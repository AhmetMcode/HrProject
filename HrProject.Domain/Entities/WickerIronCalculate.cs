using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class WickerIronCalculate : BaseEntity
    {
        public int OfferCalculateId { get; set; }
        public OfferCalculate OfferCalculate { get; set; }

        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public int Similar { get; set; }
        public decimal Weight { get; set; }
        public int SteelMeshTypeId { get; set; }
        public SteelMeshType SteelMeshType { get; set; }

    }
    public class PMWickerIronCalculate : BaseEntity
    {
        public int PmCalculateId { get; set; }
        public PmCalculate PmCalculate { get; set; }

        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public int Similar { get; set; }
        public decimal Weight { get; set; }
        public int SteelMeshTypeId { get; set; }
        public SteelMeshType SteelMeshType { get; set; }

    }
}
