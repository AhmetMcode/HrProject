using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class InvoiceAdress : BaseEntity
    {
        public int CariKartId { get; set; }
        public CariKart CariKart { get; set; }
        public string Adress { get; set; }
        public string? Contry { get; set; }
        public string? PostaCode { get; set; }
        public string? GSM1 { get; set; }
        public string? FaxNo { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public bool DefaultAddress { get; set; }
        public string EMail { get; set; }
    }
}
