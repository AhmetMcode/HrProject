using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class HesapMuavin : BaseEntity
    {
        public string? HesapName { get; set; }

        public string HesapCode { get; set; }

        public decimal? Debt { get; set; }

        public decimal? Receivable { get; set; }

        public decimal? Balance { get; set; }

        public int HesapPlaniId { get; set; }
        public HesapPlani HesapPlani { get; set; }

        public List<HesapTali> HesapTali { get; set; }
    }
}
