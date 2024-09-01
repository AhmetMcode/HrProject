using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class ConcreteRequest : BaseEntity
    {
        public DateTime RequestTime { get; set; }
        public DateTime ActionTime { get; set; }
        public string? Description { get; set; }
        public string? DescriptionRequest { get; set; }
        public decimal QuantRequest { get; set; }
        public decimal QuantAction { get; set; }
        public int ConcreteClassId { get; set; }
        public ConcreteClass ConcreteClass { get; set; }
        public string RequestUserId { get; set; }
        public ApplicationUser RequestUser { get; set; }
        public string? ActionUserId { get; set; }
        public ApplicationUser ActionUser { get; set; }
        public int? ProductionPlaceId { get; set; }
        public ProductionPlace ProductionPlace { get; set; }
        public bool Gonderildi { get; set; }
        public ICollection<ProductManifact2> ProductManifact2s { get; set; }

    }

}
