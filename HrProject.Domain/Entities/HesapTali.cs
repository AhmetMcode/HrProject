using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class HesapTali : BaseEntity
    {
        public string? HesapName { get; set; }

        public string HesapCode { get; set; }

        public decimal? Debt { get; set; }

        public decimal? Receivable { get; set; }

        public decimal? Balance { get; set; }

        public int HesapMuavinId { get; set; }
        public HesapMuavin HesapMuavin { get; set; }

        public List<HesapDetay> HesapDetay { get; set; }


    }
}
