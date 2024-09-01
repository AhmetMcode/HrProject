using HrProject.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrProject.Domain.Entities
{
    public class PmCalculate : BaseEntity
    {
        public int ProjectModuleSubId { get; set; }
        public ProjectModuleSub ProjectModuleSub { get; set; }
        public int Length { get; set; }
        public int OrderNumber { get; set; }
        public string ElementCode { get; set; }
        public int ProjectElementId { get; set; }
        public ProjectElement ProjectElement { get; set; }
        public ProjectElementType ProjectElementType { get; set; }
        public int? ProjectElementTypeId { get; set; }
        public int ElementName { get; set; }
        public ConcreteClass ConcreteClass { get; set; }
        public int ConcreteClassId { get; set; }
        public int Price { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal? GrossConcrete { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal? NetConcrete { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal? IronKg { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal? IronKgTotal { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal? IronPlusWicker { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal? GrossConcreteTotal { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal? NetConcreteTotal { get; set; }
        [Column(TypeName = "decimal(10,3)")]

        public decimal? WickerIronKg { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal? WickerIronKgTotal { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal? ANKRAJ { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal? ANKRAJTotal { get; set; }
        public bool ConfirmBy { get; set; }
        [Column(TypeName = "decimal(10,3)")]

        public decimal? RopeIronKg { get; set; }
        [Column(TypeName = "decimal(10,3)")]

        public decimal? RopeIronKgTotal { get; set; }
        public List<PMProjectElementDetails> PMProjectElementDetails { get; set; }
        public List<PmCalculateDocuments> PmCalculateDocuments { get; set; }
        public List<RopeIronPm> RopeIronPms { get; set; }
    }


}
