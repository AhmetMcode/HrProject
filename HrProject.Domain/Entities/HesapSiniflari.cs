using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class HesapSiniflari : BaseEntity
    {
        public string HesapName { get; set; }

        public string HesapCode { get; set; }

        public decimal? Debt { get; set; }

        public decimal? Receivable { get; set; }

        public decimal? Balance { get; set; }

        public List<HesapGruplari> HesapGruplari { get; set; }

    }
}
