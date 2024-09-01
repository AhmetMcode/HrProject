using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class ProductPlan : BaseEntity
    {
        public int OfferId { get; set; }
        public int ProjectModuleSubId { get; set; }

        public TerminType TerminType { get; set; }
        public PlanType PlanType { get; set; }
        public bool Actual { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<ProductPlanSubPlanned> ProductPlanSubPlanned { get; set; }
    }
    public class ProductPlanSubPlanned : BaseEntity
    {
        public PlanType PlanType { get; set; }
        public TerminType TerminType { get; set; }
        public bool Actual { get; set; }
        public int PatternId { get; set; }
        public int Quant { get; set; }
        public int CanQuant { get; set; }
        public Pattern Pattern { get; set; }
        public int ProductPlanId { get; set; }
        public int? PmCalculateId { get; set; }
        public PmCalculate PmCalculate { get; set; }

        public int? OfferCalculateId { get; set; }
        public OfferCalculate OfferCalculate { get; set; }
        public ProductPlan ProductPlan { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<ProductPlanDailyPlanned> ProductPlanDailyPlanned { get; set; }
    }
    public class ProductPlanDailyPlanned : BaseEntity
    {
        public int ProductPlanSubPlannedId { get; set; }
        public ProductPlanSubPlanned ProductPlanSubPlanned { get; set; }
        public bool Actual { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<ProductPlanProductPlanned> ProductPlanProductPlanned { get; set; }

    }
    public class ProductPlanProductPlanned : BaseEntity
    {
        public int ProductPlanDailyPlannedId { get; set; }
        public int OrderName { get; set; }

        public ProductPlanDailyPlanned ProductPlanDailyPlanned { get; set; }
        public ProductManifact2 ProductManifact2 { get; set; }
        public bool Actual { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
    public enum TerminType
    {
        Tamam,
        Olabilir,
        Dusuk
    }
    public enum PlanType
    {
        Teklif,
        Proje
    }
}
