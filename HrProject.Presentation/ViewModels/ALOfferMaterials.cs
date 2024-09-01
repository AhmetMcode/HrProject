using HrProject.Domain.Entities;
using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Presentation.ViewModels
{
    public class ALOfferMaterials
    {
        public List<OfferMaterials> OfferMaterials { get; set; }
        public int OfferCostCategoryId { get; set; }
        public List<OfferCostCategory> OfferCostCategory { get; set; }

        public int CurrentValueId { get; set; }
        public List<CurrentValue> CurrentValue { get; set; }
        public bool Formula { get; set; }
        public Formulas? Formulas { get; set; }
        public TypesFormulas? TypesFormulas { get; set; }
        public string? FormulStr { get; set; }
        public int Wastage { get; set; }
        public decimal Enflasyon { get; set; }
        public bool IsActive { get; set; }
        public int OrderNumber { get; set; }

    }
}
