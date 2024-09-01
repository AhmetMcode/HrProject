using HrProject.Domain.Entities;
using HrProject.Domain.Enums;

namespace HrProject.Presentation.ViewModels
{
    public class CariKartViewModel
    {

    }
    public class AddCariKartViewModel
    {
        public CariKartType CariKartType { get; set; }
        public CariType CariType { get; set; }
        public bool Status { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Explanation { get; set; }
        public int TaxOfficeId { get; set; }
        public TaxOffice TaxOffice { get; set; }
        public string TaxNumber { get; set; }
        public string EMail { get; set; }
        public bool DefaultAddress { get; set; }
        public InvoiceAdress InvoiceAdress { get; set; }
        public int AccountNo { get; set; }
        public string IBAN { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public decimal FirstBalance { get; set; }
        public DateTime FirstBalanceDate { get; set; }
        public decimal FinalBalance { get; set; }

    }
    public class AddCariKartViewModelMobile
    {
        public CariKartType CariKartType { get; set; }
        public CariType CariType { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Explanation { get; set; }
        public int TaxOfficeId { get; set; }
        public string TaxNumber { get; set; }
        public string EMail { get; set; }
    }
    public class EditCariKartViewModel
    {
        public CariKart CariKart { get; set; }
        public bool DefaultAddress { get; set; }
        public List<InvoiceAdress> InvoiceAdresses { get; set; }
        public CariRisk CariRisk { get; set; }
        public CariBank CariBank { get; set; }
        public OtherCariRisk OtherCariRisk { get; set; }
        public int AccountNo { get; set; }
        public string IBAN { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public decimal FirstBalance { get; set; }
        public DateTime FirstBalanceDate { get; set; }
        public decimal FinalBalance { get; set; }
    }
}
