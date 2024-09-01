using HrProject.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrProject.Domain.Entities
{
    public class PMProjectElementDetails : BaseEntity
    {
        public int PmCalculateId { get; set; }
        public PmCalculate? PmCalculate { get; set; }
        public string PozNumber { get; set; }
        public int Price { get; set; }
        public int Similar { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal Size { get; set; }

        [Column(TypeName = "decimal(10,3)")]
        public decimal TotalWeight { get; set; }
        public int IronDiameterWeightId { get; set; }
        public IronDiameterWeight? IronDiameterWeight { get; set; }
    }
}
