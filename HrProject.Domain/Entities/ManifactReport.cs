using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class ManifactReport : BaseEntity
    {
        public int ProjectModuleSubId { get; set; }
        public ProjectModuleSub ProjectModuleSub { get; set; }
        public decimal BirimMaaliyet { get; set; }
        public ManifactReportStatus ManifactReportStatus { get; set; }
        public decimal SozlesmeMetraj { get; set; }
        public decimal ProjeMetraj { get; set; }
        public decimal Uretilen { get; set; }
        public decimal Kalan { get; set; }
        public decimal UretilmisMaaliyet { get; set; }
        public decimal KalanMaaliyet { get; set; }
        public decimal ToplamMaaliyet { get; set; }
    }
    public enum ManifactReportStatus
    {
        Baslanmadi = 0,
        Baslandi = 1,
        Durduruldu = 2,
        Bitirildi = 3,
    }
}
