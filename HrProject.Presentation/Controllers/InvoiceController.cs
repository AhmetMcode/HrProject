using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Models;
using HrProject.Presentation.ViewModels;

namespace HrProject.Presentation.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceStockService invoiceStockService;
        private readonly IInvoiceStockTaxService invoiceStockTaxService;
        private readonly IInvoiceStockDiscountService invoiceStockDiscountService;
        private readonly IInvoiceSubWaybillService invoiceSubWaybillService;
        private readonly IInvoiceService invoiceService;
        private readonly IInvoiceAdditionalDocumentService invoiceAdditionalDocumentService;
        private readonly IInvoiceGoodsAcceptanceService invoiceGoodsAcceptanceService;
        private readonly ICariKartService cariKartService;
        private readonly IMapper mapper;
        private readonly IOutWaybillService outWaybillService;
        private readonly IAccountService accountService;
        private readonly IStockService stockService;
        private readonly IUnitService unitService;
        private readonly ISaleVatService saleVatService;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IStockChangeService stockChangeService;
        private readonly IWareHouseService wareHouseService;

        public InvoiceController(IInvoiceStockService invoiceStockService, IInvoiceStockTaxService invoiceStockTaxService, IInvoiceStockDiscountService invoiceStockDiscountService, IInvoiceSubWaybillService invoiceSubWaybillService, IInvoiceService invoiceService, IInvoiceAdditionalDocumentService invoiceAdditionalDocumentService, IInvoiceGoodsAcceptanceService invoiceGoodsAcceptanceService, ICariKartService cariKartService, IMapper mapper, IOutWaybillService outWaybillService, IAccountService accountService, IStockService stockService, IUnitService unitService, ISaleVatService saleVatService, IWebHostEnvironment hostEnvironment, IStockChangeService stockChangeService, IWareHouseService wareHouseService)

        {
            this.invoiceStockService = invoiceStockService;
            this.invoiceStockTaxService = invoiceStockTaxService;
            this.invoiceStockDiscountService = invoiceStockDiscountService;
            this.invoiceSubWaybillService = invoiceSubWaybillService;
            this.invoiceService = invoiceService;
            this.invoiceAdditionalDocumentService = invoiceAdditionalDocumentService;
            this.invoiceGoodsAcceptanceService = invoiceGoodsAcceptanceService;
            this.cariKartService = cariKartService;
            this.mapper = mapper;
            this.outWaybillService = outWaybillService;
            this.accountService = accountService;
            this.stockService = stockService;
            this.unitService = unitService;
            this.saleVatService = saleVatService;
            this.hostEnvironment = hostEnvironment;
            this.stockChangeService = stockChangeService;
            this.wareHouseService = wareHouseService;
        }

        [HttpGet]
        public IActionResult AddInvoice()
        {
            ViewBag.CariKarts = cariKartService.GetAll();
            var invoice = invoiceService.GetIncludeInvoice();

            InvoiceViewModel invoiceViewModel = new InvoiceViewModel();
            invoiceViewModel.Invoices = invoice;

            return View(invoiceViewModel);
        }

        [HttpPost]
        public IActionResult AddInvoice(InvoiceViewModel invoiceViewModel)
        {
            ViewBag.CariKarts = cariKartService.GetAll();
            Invoice invoice = invoiceViewModel.Invoice;
            invoice.CreatedTime = DateTime.Now;
            try
            {
                invoiceService.AddInvoice(invoice);

            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("GetInvoiceDraft");
        }

        [HttpGet]
        public IActionResult GetCariById(int id)
        {
            var carikart = invoiceService.GetCariById(id);
            if (carikart != null)
            {
                return Json(new
                {
                    carikart.TaxNumber,

                    TaxOffice = new
                    {
                        carikart.TaxOffice?.Name,
                        carikart.TaxOffice?.Code,
                    }
                });
            }
            return Json(null);
        }

        [HttpGet]
        public IActionResult GetInvoiceAdressByCariId(int id)
        {
            var invoiceadres = invoiceService.GetInvoiceAdressByCariId(id);

            if (invoiceadres != null)
            {
                return Json(new
                {
                    invoiceadres.Adress,
                    invoiceadres.GSM1,
                    invoiceadres.FaxNo,
                    invoiceadres.PostaCode,
                    invoiceadres.EMail,

                    City = new
                    {
                        invoiceadres.City?.Name,
                    },
                    District = new
                    {
                        invoiceadres.District?.Name,
                    }
                });
            }
            return Json(null);
        }

        [HttpGet]
        public IActionResult GetInvoiceDraft()
        {
            InvoiceViewModel invoiceViewModel = new InvoiceViewModel();
            invoiceViewModel.Invoices = invoiceService.GetIncludeInvoice();
            return View(invoiceViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateInvoice(int id)
        {
            ViewBag.CariKarts = cariKartService.GetAll();
            ViewBag.OutWaybill = outWaybillService.GetAll();
            ViewBag.Accounts = accountService.GetAll();
            ViewBag.Stocks = stockService.GetAll();
            ViewBag.Units = unitService.GetAll();
            ViewBag.SaleVATs = saleVatService.GetAll();


            InvoiceViewModel invoiceViewModel = new InvoiceViewModel();
            invoiceViewModel.Invoice = invoiceService.GetInvoiceInclude(id);
            invoiceViewModel.Invoice.OrderDocumentFile = invoiceService.GetInvoiceInclude(id).OrderDocumentFile;
            invoiceViewModel.InvoiceSubWaybills = invoiceSubWaybillService.GetIncludeISubWayBill();
            invoiceViewModel.InvoiceGoodsAcceptances = invoiceGoodsAcceptanceService.GetAll();
            invoiceViewModel.InvoiceStocks = invoiceStockService.GetIncludeInvoiceStock().Where(x => x.InvoiceId == id).ToList();
            invoiceViewModel.InvoiceAdditionalDocuments = invoiceAdditionalDocumentService.GetAll();

            //await invoiceService.FaturaToplamGuncelleme(id);

            return View(invoiceViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInvoiceGenel(InvoiceViewModel invoiceViewModel)
        {
            var invoices = invoiceService.GetInvoiceInclude(invoiceViewModel.Invoice.Id);

            invoices.CariKartId = invoiceViewModel.Invoice.CariKartId;
            invoices.ETTN = invoiceViewModel.Invoice.ETTN;
            invoices.CustomizationNo = invoiceViewModel.Invoice.CustomizationNo;
            invoices.InvoiceNo = invoiceViewModel.Invoice.InvoiceNo;
            invoices.InvoiceScenarioTypeEnum = invoiceViewModel.Invoice.InvoiceScenarioTypeEnum;
            invoices.Date = invoiceViewModel.Invoice.Date;
            invoices.InvoiceTypeEnum = invoiceViewModel.Invoice.InvoiceTypeEnum;
            invoices.CurrencyType = invoiceViewModel.Invoice.CurrencyType;
            invoices.CurrencyRate = invoiceViewModel.Invoice.CurrencyRate;
            invoices.CariTCVKN = invoiceViewModel.Invoice.CariTCVKN;
            invoices.CariTradeRegisterNo = invoiceViewModel.Invoice.CariTradeRegisterNo;
            invoices.CariTaxOffice = invoiceViewModel.Invoice.CariTaxOffice;
            invoices.CariVehicleNo = invoiceViewModel.Invoice.CariVehicleNo;
            invoices.CariVehiclePlate = invoiceViewModel.Invoice.CariVehiclePlate;
            invoices.CariAdress = invoiceViewModel.Invoice.CariAdress;
            invoices.CariCity = invoiceViewModel.Invoice.CariCity;
            invoices.CariTel = invoiceViewModel.Invoice.CariTel;
            invoices.CariFax = invoiceViewModel.Invoice.CariFax;
            invoices.CariPostCode = invoiceViewModel.Invoice.CariPostCode;
            invoices.CariDistrict = invoiceViewModel.Invoice.CariDistrict;
            invoices.CariEMail = invoiceViewModel.Invoice.CariEMail;
            invoices.TotalInvoiceBaseAmount = invoiceViewModel.Invoice.TotalInvoiceBaseAmount;
            invoices.TotalInvoiceDiscount = invoiceViewModel.Invoice.TotalInvoiceDiscount;
            invoices.TotalInvoiceInsuranceAmount = invoiceViewModel.Invoice.TotalInvoiceInsuranceAmount;
            invoices.TotalInvoiceNavlunAmount = invoiceViewModel.Invoice.TotalInvoiceNavlunAmount;
            invoices.TotalInvoiceFOBAmount = invoiceViewModel.Invoice.TotalInvoiceFOBAmount;
            invoices.TotalInvoicemountWithoutTax = invoiceViewModel.Invoice.TotalInvoicemountWithoutTax;
            invoices.TotalInvoicemountWithTax = invoiceViewModel.Invoice.TotalInvoicemountWithTax;
            invoices.TotalInvoicemountPaid = invoiceViewModel.Invoice.TotalInvoicemountPaid;
            invoices.TotalInvoicemountPaidWriting = invoiceViewModel.Invoice.TotalInvoicemountPaidWriting;
            invoices.LowerDiscountRate = invoiceViewModel.Invoice.LowerDiscountRate;
            invoices.LowerDiscountAmount = invoiceViewModel.Invoice.LowerDiscountAmount;
            invoices.LowerDiscountDescription = invoiceViewModel.Invoice.LowerDiscountDescription;
            invoices.InvoiceDescription = invoiceViewModel.Invoice.InvoiceDescription;

            invoiceService.Update(invoices);

            return RedirectToAction("UpdateInvoice", new { id = invoiceViewModel.Invoice.Id });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInvoiceSipIrsaliye(InvoiceViewModel invoiceViewModel, IFormFile siparis)
        {
            var invoices = invoiceService.GetInvoiceInclude(invoiceViewModel.Invoice.Id);

            invoices.OrderDate = invoiceViewModel.Invoice.OrderDate;
            invoices.OrderNo = invoiceViewModel.Invoice.OrderNo;
            invoices.OrderDocumentDate = invoiceViewModel.Invoice.OrderDocumentDate;
            invoices.OrderDocumentNo = invoiceViewModel.Invoice.OrderDocumentNo;
            invoices.OrderDocumentFile = FileWork.ReturnFileName(siparis, "InvoiceOrder", hostEnvironment);

            invoiceService.Update(invoices);

            return RedirectToAction("UpdateInvoice", new { id = invoiceViewModel.Invoice.Id });
        }

        [HttpPost]
        public IActionResult UpdateInvoiceOdeme(InvoiceViewModel invoiceViewModel)
        {
            var invoices = invoiceService.GetInvoiceInclude(invoiceViewModel.Invoice.Id);
            invoices.InvoicePaymentMethodEnum = invoiceViewModel.Invoice.InvoicePaymentMethodEnum;
            invoices.LastPaymentDate = invoiceViewModel.Invoice.LastPaymentDate;
            invoices.Account2Id = invoiceViewModel.Invoice.Account2Id;
            invoices.InvoicePaymentChannelEnum = invoiceViewModel.Invoice.InvoicePaymentChannelEnum;
            invoices.PaymentDescription = invoiceViewModel.Invoice.PaymentDescription;
            invoices.ReceiptNo = invoiceViewModel.Invoice.ReceiptNo;
            invoices.ReceiptDate = invoiceViewModel.Invoice.ReceiptDate;
            invoices.ReceiptZReportNo = invoiceViewModel.Invoice.ReceiptZReportNo;
            invoices.ReceiptOKCNo = invoiceViewModel.Invoice.ReceiptOKCNo;
            invoices.DelayPenaltyRate = invoiceViewModel.Invoice.DelayPenaltyRate;
            invoices.DelayPenaltyAmount = invoiceViewModel.Invoice.DelayPenaltyAmount;
            invoices.DelayPenaltyDescription = invoiceViewModel.Invoice.DelayPenaltyDescription;
            invoiceService.Update(invoices);
            return RedirectToAction("UpdateInvoice", new { id = invoiceViewModel.Invoice.Id });
        }

        [HttpGet]
        public IActionResult DeleteInvoice(int id)
        {
            var invoice = invoiceService.GetInvoiceInclude(id);

            foreach (var invoicestock in invoice.InvoiceStocks)
            {
                foreach (var stockchange in invoicestock.StockChanges)
                {
                    stockChangeService.Delete(stockchange.Id);
                }
                invoiceStockService.Delete(invoicestock.Id);
            }

            invoiceService.Delete(invoice.Id);
            return RedirectToAction("GetInvoiceDraft");
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoiceStock(InvoiceViewModel vm)
        {
            if (vm.InvoiceStock != null)
            {
                InvoiceStock invoiceStock = vm.InvoiceStock;
                invoiceStock.InvoiceId = vm.InvoiceStock.InvoiceId;
                invoiceStock.InvoiceStockDiscounts = vm.InvoiceStock.InvoiceStockDiscounts ?? new List<InvoiceStockDiscount>();
                invoiceStock.InvoiceStockTaxs = vm.InvoiceStock.InvoiceStockTaxs ?? new List<InvoiceStockTax>();
                invoiceStock.StockChanges = vm.InvoiceStock.StockChanges ?? new List<StockChange>();
                foreach (var item in invoiceStock.StockChanges)
                {
                    item.DateChange = DateTime.Now;
                }


                if (invoiceStock.InvoiceStockDiscounts.All(d => d.DiscountRate == 0))
                {
                    invoiceStock.InvoiceStockDiscounts = null;
                }

                if (invoiceStock.InvoiceStockTaxs.All(t => t.TaxRate == 0))
                {
                    invoiceStock.InvoiceStockTaxs = null;
                }

                invoiceStockService.Insert(invoiceStock);

            }
            else
            {
                ErrorViewModel error = new ErrorViewModel();
                error.Message = "Stok bilgisi Girilmedi";
                return View("Error", error);
            }
            return RedirectToAction("UpdateInvoice", new { id = vm.InvoiceStock.InvoiceId });
        }

        [HttpPost]
        public IActionResult DeleteInvoiceStock(int id, int invoiceId)
        {
            try
            {
                var invoicestok = invoiceStockService.GetInvoiceStockInclude(id);

                foreach (var item in invoicestok.StockChanges)
                {
                    if (item != null)
                    {
                        stockChangeService.Delete(item.Id);
                    }
                    else
                    {
                        continue;
                    }
                }
                invoiceStockService.Delete(invoicestok.Id);

                return Json("Silme işlemi başarıyla tamamlandı.");
            }
            catch (Exception ex)
            {
                return Json($"Hata oluştu: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult DeleteInvoiceStockDiscount(int id)
        {
            invoiceStockDiscountService.Delete(id);
            return Json("silindi");
        }

        [HttpPost]
        public IActionResult DeleteInvoiceStockTax(int id)
        {
            invoiceStockTaxService.Delete(id);
            return Json("işlembaşarılı");
        }

        [HttpPost]
        public IActionResult DeleteInvoiceStockChange(int id)
        {
            stockChangeService.Delete(id);
            return Json("işlembaşarılı");
        }

        [HttpGet]
        public IActionResult UpdateInvoiceStockDetails(int id)
        {

            ViewBag.Stocks = stockService.GetAll();
            ViewBag.Units = unitService.GetAll();
            ViewBag.SaleVATs = saleVatService.GetAll();
            var invoiceStock = invoiceStockService.GetInvoiceStockInclude(id);
            InvoiceViewModel invoiceViewModel = new InvoiceViewModel();
            invoiceViewModel.InvoiceStock = invoiceStock;
            return PartialView(invoiceViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInvoiceStockDetails(InvoiceViewModel vm)
        {

            var existingInvoiceStock = invoiceStockService.GetInvoiceStockInclude(vm.InvoiceStock.Id);

            if (existingInvoiceStock != null)
            {
                foreach (var updatedDiscount in vm.InvoiceStock.InvoiceStockDiscounts)
                {
                    var existingDiscount = existingInvoiceStock.InvoiceStockDiscounts.FirstOrDefault(d => d.Id == updatedDiscount.Id);

                    if (existingDiscount != null)
                    {
                        existingDiscount.DiscountAmount = updatedDiscount.DiscountAmount;
                        existingDiscount.DiscountRate = updatedDiscount.DiscountRate;
                        existingDiscount.Description = updatedDiscount.Description;
                        invoiceStockDiscountService.Update(existingDiscount);
                    }
                    else
                    {
                        if (updatedDiscount.DiscountRate != 0)
                        {
                            invoiceStockDiscountService.Insert(updatedDiscount);

                        }
                    }
                }

                foreach (var updatedTax in vm.InvoiceStock.InvoiceStockTaxs)
                {
                    var existingTax = existingInvoiceStock.InvoiceStockTaxs.FirstOrDefault(t => t.Id == updatedTax.Id);

                    if (existingTax != null)
                    {
                        existingTax.TaxRate = updatedTax.TaxRate;
                        existingTax.TaxAmount = updatedTax.TaxAmount;
                        existingTax.InvoiceTaxTypeEnum = updatedTax.InvoiceTaxTypeEnum;
                        invoiceStockTaxService.Update(existingTax);
                    }
                    else
                    {
                        if (updatedTax.TaxRate != 0)
                        {
                            invoiceStockTaxService.Insert(updatedTax);

                        }
                    }
                }

                foreach (var updatedstock in vm.InvoiceStock.StockChanges)
                {
                    var existingstock = existingInvoiceStock.StockChanges.FirstOrDefault(t => t.Id == updatedstock.Id);

                    if (existingstock != null)
                    {
                        existingstock.StockId = updatedstock.StockId;
                        existingstock.ExitWareHouseId = updatedstock.ExitWareHouseId;
                        existingstock.Quantity = updatedstock.Quantity;
                        stockChangeService.Update(existingstock);
                    }
                    else
                    {
                        if (updatedstock.Quantity != 0)
                        {
                            stockChangeService.Insert(updatedstock);

                        }
                    }
                }

                existingInvoiceStock.Quantity = vm.InvoiceStock.Quantity;
                existingInvoiceStock.UnitId = vm.InvoiceStock.UnitId;
                existingInvoiceStock.SaleVatId = vm.InvoiceStock.SaleVatId;
                existingInvoiceStock.VATAmount = vm.InvoiceStock.VATAmount;
                existingInvoiceStock.InvoiceVATExemptionReasonEnum = vm.InvoiceStock.InvoiceVATExemptionReasonEnum;
                existingInvoiceStock.UnitPrice = vm.InvoiceStock.UnitPrice;
                existingInvoiceStock.GoodsOrServiceAmount = vm.InvoiceStock.GoodsOrServiceAmount;
                existingInvoiceStock.AmountIncludingVat = vm.InvoiceStock.AmountIncludingVat;
                existingInvoiceStock.OutStocksOrNot = vm.InvoiceStock.OutStocksOrNot;
                invoiceStockService.Update(existingInvoiceStock);
            }
            else
            {
            }
            return RedirectToAction("UpdateInvoice", new { id = vm.InvoiceStock.InvoiceId });
        }

        [HttpPost]
        public async Task<IActionResult> AddInvoiceWaybill(InvoiceViewModel vm, IFormFile dosya)
        {
            if (vm.InvoiceSubWaybill != null)
            {
                InvoiceSubWaybill invoiceSubWaybill = vm.InvoiceSubWaybill;
                invoiceSubWaybill.OutWaybill2Document = FileWork.ReturnFileName(dosya, "InvoiceSubWayBill", hostEnvironment);
                invoiceSubWaybill.InvoiceId = vm.InvoiceSubWaybill.InvoiceId;

                invoiceSubWaybillService.Insert(invoiceSubWaybill);
            }
            else
            {
                ErrorViewModel error = new ErrorViewModel();
                error.Message = "İrsaliye bilgisi Girilmedi";
                return View("Error", error);
            }
            return RedirectToAction("UpdateInvoice", new { id = vm.InvoiceSubWaybill.InvoiceId });
        }

        [HttpPost]
        public IActionResult DeleteInvoiceWaybill(int id)
        {
            invoiceSubWaybillService.Delete(id);
            return Json("silindi");
        }

        [HttpPost]
        public async Task<IActionResult> AddGoodsAcceptance(InvoiceViewModel vm, IFormFile dosya)
        {
            if (vm.InvoiceGoodsAcceptance != null)
            {
                InvoiceGoodsAcceptance invoiceGoodsAcceptance = vm.InvoiceGoodsAcceptance;

                invoiceGoodsAcceptance.File = FileWork.ReturnFileName(dosya, "invoiceGoodsAcceptance", hostEnvironment);
                invoiceGoodsAcceptance.InvoiceId = vm.InvoiceGoodsAcceptance.InvoiceId;
                invoiceGoodsAcceptanceService.Insert(invoiceGoodsAcceptance);

            }
            else
            {

                ErrorViewModel error = new ErrorViewModel();
                error.Message = "Mal bilgisi Girilmedi";
                return View("Error", error);
            }
            return RedirectToAction("UpdateInvoice", new { id = vm.InvoiceGoodsAcceptance.InvoiceId });
        }

        [HttpPost]
        public IActionResult DeleteGoodsAcceptance(int id)
        {
            invoiceGoodsAcceptanceService.Delete(id);
            return Json("silindi");
        }

        [HttpPost]
        public async Task<IActionResult> AddAddDocumentInvoice(InvoiceViewModel vm, IFormFile dosya1)
        {
            if (vm.InvoiceAdditionalDocument != null)
            {
                InvoiceAdditionalDocument invoiceAdditionalDocument = vm.InvoiceAdditionalDocument;

                invoiceAdditionalDocument.File = FileWork.ReturnFileName(dosya1, "InvoiceAddDocument", hostEnvironment);

                invoiceAdditionalDocument.InvoiceId = vm.InvoiceAdditionalDocument.InvoiceId;
                invoiceAdditionalDocumentService.Insert(invoiceAdditionalDocument);

            }
            else
            {
                ErrorViewModel error = new ErrorViewModel();
                error.Message = "Ek Belge bilgisi Girilmedi";
                return View("Error", error);
            }
            return RedirectToAction("UpdateInvoice", new { id = vm.InvoiceAdditionalDocument.InvoiceId });

        }

        [HttpPost]
        public IActionResult DeleteDocumentInvoice(int id)
        {
            invoiceAdditionalDocumentService.Delete(id);
            return Json("silindi");
        }

        [HttpGet]
        public IActionResult CalculateInoviceStock(int id)
        {
            var inf = invoiceStockService.CalculateInoviceStock(id);
            return Json(inf);
        }

        [HttpGet]
        public IActionResult GetWareHousesByStockId(int stockId)
        {

            var stockChanges = stockChangeService.GetByChangesByStockId(stockId);

            var wareHouses = stockChanges
                .Where(x => x.EntryWareHouseId != null || x.ExitWareHouseId != null)
                .GroupBy(x => x.EntryWareHouseId ?? x.ExitWareHouseId)
                .Select(g => new
                {
                    Id = g.Key,
                    WareHouseName = g.FirstOrDefault()?.EntryWareHouse?.Name
                })
                .ToList();

            return new JsonResult(wareHouses);
        }

    }
}
