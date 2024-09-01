using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class HesapPlani : BaseEntity
    {
        public string? HesapName { get; set; }

        public string HesapCode { get; set; }

        public decimal? Debt { get; set; }

        public decimal? Receivable { get; set; }

        public decimal? Balance { get; set; }

        public int HesapGruplariId { get; set; }
        public HesapGruplari HesapGruplari { get; set; }

        public List<HesapMuavin> HesapMuavin { get; set; }
    }
}
