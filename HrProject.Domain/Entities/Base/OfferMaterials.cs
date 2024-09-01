using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities.Base
{
    public class OfferMaterials : BaseEntity
    {
        public int OfferCostCategoryId { get; set; }
        public OfferCostCategory OfferCostCategory { get; set; }

        public int CurrentValueId { get; set; }
        public int OrderNumber { get; set; }
        public CurrentValue CurrentValue { get; set; }
        public bool Formula { get; set; }
        public string? FormulStr { get; set; }
        public Formulas? Formulas { get; set; }
        public TypesFormulas? TypesFormulas { get; set; }
        public int Wastage { get; set; }
        public decimal Enflasyon { get; set; }
        public bool IsActive { get; set; }
    }
}
