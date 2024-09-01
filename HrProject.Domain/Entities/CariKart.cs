using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class CariKart : BaseEntity
    {
        public CariKartType CariKartType { get; set; }
        public CariType CariType { get; set; }
        public bool Status { get; set; }
        public string? Title { get; set; }
        public string? Code { get; set; }
        public string? Explanation { get; set; }
        public int? TaxOfficeId { get; set; }
        public TaxOffice TaxOffice { get; set; }
        public List<InvoiceAdress> InvoiceAdresses { get; set; }
        public CariBank CariBank { get; set; }
        public OtherCariRisk OtherCariRisk { get; set; }
        public CariRisk CariRisk { get; set; }
        public string? TaxNumber { get; set; }
        public string? EMail { get; set; }
        public int AccountNo { get; set; }
        public string? IBAN { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public decimal FirstBalance { get; set; }
        public DateTime FirstBalanceDate { get; set; }
        public decimal FinalBalance { get; set; }
    }
}
