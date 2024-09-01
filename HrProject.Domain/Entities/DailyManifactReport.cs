using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class DailyManifactReport : BaseEntity
    {
        public int PmCalculateId { get; set; }
        public PmCalculate PmCalculate { get; set; }
        public int Adet { get; set; }
        public int UretilenAdet { get; set; }
        public int KalanAdet { get; set; }
        public decimal UretilenMetrekup { get; set; }
        public decimal ToplamMetrekup { get; set; }
    }
    public class DailyManifactReportDetail : BaseEntity
    {
        public int DailyManifactReportId { get; set; }
        public DailyManifactReport DailyManifactReport { get; set; }
        public DateTime DateTime { get; set; }
        public int Adet { get; set; }
    }
}
