using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class HesapGruplari : BaseEntity
    {
        public string? HesapName { get; set; }

        public string HesapCode { get; set; }

        public decimal? Debt { get; set; }

        public decimal? Receivable { get; set; }

        public decimal? Balance { get; set; }

        public int HesapSiniflariId { get; set; }
        public HesapSiniflari HesapSiniflari { get; set; }

        public List<HesapPlani> HesapPlani { get; set; }
    }
}
