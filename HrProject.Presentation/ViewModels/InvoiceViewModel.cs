using HrProject.Domain.Entities;
using HrProject.Domain.Enums;

namespace HrProject.Presentation.ViewModels
{
    public class InvoiceViewModel
    {
        public InvoiceScenarioTypeEnum InvoiceScenarioTypeEnum { get; set; }
        public InvoiceTypeEnum InvoiceTypeEnum { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public InvoicePaymentMethodEnum InvoicePaymentMethodEnum { get; set; }
        public InvoicePaymentChannelEnum InvoicePaymentChannelEnum { get; set; }
        public IEnumerable<InvoiceStock> InvoiceStocks { get; set; }
        public InvoiceStock InvoiceStock { get; set; }
        public IEnumerable<InvoiceSubWaybill> InvoiceSubWaybills { get; set; }
        public InvoiceSubWaybill InvoiceSubWaybill { get; set; }
        public IEnumerable<InvoiceAdditionalDocument> InvoiceAdditionalDocuments { get; set; }
        public InvoiceAdditionalDocument InvoiceAdditionalDocument { get; set; }
        public IEnumerable<InvoiceGoodsAcceptance> InvoiceGoodsAcceptances { get; set; }
        public InvoiceGoodsAcceptance InvoiceGoodsAcceptance { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; }
        public Invoice Invoice { get; set; }
        public int? CariKartId { get; set; }
        public CariKart CariKart { get; set; }
        public int Account2Id { get; set; }
        public Account2 Account2 { get; set; }
    }
}
