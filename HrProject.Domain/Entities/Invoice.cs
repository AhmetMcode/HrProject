using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public InvoiceScenarioTypeEnum InvoiceScenarioTypeEnum { get; set; }
        public InvoiceTypeEnum InvoiceTypeEnum { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public InvoicePaymentMethodEnum InvoicePaymentMethodEnum { get; set; }
        public InvoicePaymentChannelEnum InvoicePaymentChannelEnum { get; set; }
        public List<InvoiceStock> InvoiceStocks { get; set; }
        public List<InvoiceSubWaybill> InvoiceSubWaybills { get; set; }
        public List<InvoiceAdditionalDocument> InvoiceAdditionalDocuments { get; set; }
        public List<InvoiceGoodsAcceptance> InvoiceGoodsAcceptances { get; set; }
        public int? CariKartId { get; set; }
        public CariKart? CariKart { get; set; }
        public int? Account2Id { get; set; }
        public Account2 Account2 { get; set; }
        public string? ETTN { get; set; }
        public string? CustomizationNo { get; set; }
        public string? InvoiceNo { get; set; }
        public DateTime? Date { get; set; }
        public decimal CurrencyRate { get; set; }
        public string? CariTCVKN { get; set; }
        public string? CariTradeRegisterNo { get; set; }
        public string? CariOfficialTitle { get; set; }
        public string? CariTaxNumber { get; set; }
        public string? CariTaxOffice { get; set; }
        public string? CariVehicleNo { get; set; }
        public string? CariVehiclePlate { get; set; }
        public string? CariAdress { get; set; }
        public string? CariCity { get; set; }
        public string? CariDistrict { get; set; }
        public string? CariPostCode { get; set; }
        public string? CariEMail { get; set; }
        public string? CariTel { get; set; }
        public string? CariFax { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderNo { get; set; }
        public DateTime OrderDocumentDate { get; set; }
        public int OrderDocumentNo { get; set; }
        public string? OrderDocumentFile { get; set; }
        public DateTime LastPaymentDate { get; set; }
        public string? PaymentDescription { get; set; }
        public decimal DelayPenaltyRate { get; set; }
        public decimal DelayPenaltyAmount { get; set; }
        public string? DelayPenaltyDescription { get; set; }
        public string? ReceiptNo { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string? ReceiptZReportNo { get; set; }
        public string? ReceiptOKCNo { get; set; }
        public decimal TotalInvoiceBaseAmount { get; set; }
        public decimal TotalInvoiceDiscount { get; set; }
        public decimal TotalInvoiceInsuranceAmount { get; set; }
        public decimal TotalInvoiceNavlunAmount { get; set; }
        public decimal TotalInvoiceFOBAmount { get; set; }
        public decimal TotalInvoicemountWithoutTax { get; set; }
        public decimal TotalInvoicemountWithTax { get; set; }
        public decimal TotalInvoicemountPaid { get; set; }
        public string? TotalInvoicemountPaidWriting { get; set; }
        public string? InvoiceDescription { get; set; }
        public decimal LowerDiscountRate { get; set; }
        public decimal LowerDiscountAmount { get; set; }
        public decimal LowerDiscountDescription { get; set; }
    }
}
