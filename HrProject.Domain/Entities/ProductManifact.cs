using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{


    public class ProductManifactDetail : BaseEntity
    {

        public int ProductManifact2Id { get; set; }
        public ProductManifact2 ProductManifact { get; set; }
        public int ProjectElementStepId { get; set; }
        public ProjectElementStep ProjectElementStep { get; set; }
        public ProductStepDurumEnum ProductStepEnum { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public List<ProductManifactDetailImages> ProductManifactDetailImages { get; set; }

    }
    public class ProductManifactDetailImages : BaseEntity
    {
        public int ProductManifactDetailId { get; set; }
        public ProductManifactDetail ProductManifactDetail { get; set; }
        public string ImagePath { get; set; }

    }
    public enum ProductStepDurumEnum
    {
        None = 1,
        Start = 2,
        Finish = 3,
        Revize = 4,
    }
    public class ProductManifact2 : BaseEntity
    {

        public bool Uretildi { get; set; }
        public DateTime UretimBitisZamani { get; set; }
        public int? ConcreteRequestId { get; set; }
        public ConcreteRequest ConcreteRequest { get; set; }
        public int ProductPlanProductPlannedId { get; set; }
        public ProductPlanProductPlanned ProductPlanProductPlanned { get; set; }
        public int OrderNumber { get; set; }
        public int? IronProductionPlaceId { get; set; }
        public ProductionPlace? IronProductionPlace { get; set; }
        public int? ConcreteProductionPlaceId { get; set; }
        public ProductionPlace? ConcreteProductionPlace { get; set; }
        public List<ProductManifactDetail> ProductManifactDetail { get; set; }
        public string? PlanningDesc { get; set; }
        public string? ManifactDesc { get; set; }
    }
}
