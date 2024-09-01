using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class HolNesne : BaseEntity
    {
        public string Ad { get; set; }
        public bool Aktif { get; set; }
        public decimal Genlisik { get; set; }
        public decimal Uzunluk { get; set; }
        public int ProductionPlaceId { get; set; }
        public ProductionPlace ProductionPlace { get; set; }
        public decimal Top { get; set; }
        public decimal Left { get; set; }
    }

}
