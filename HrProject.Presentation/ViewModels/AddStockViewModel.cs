using HrProject.Domain.Enums;
using HrProject.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace HrProject.Presentation.ViewModels;

public class AddStockViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Stok adı alanı zorunludur.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Kod alanı zorunludur.")]
    public string Code { get; set; }
    public string? Barcode { get; set; }
    public string? Description { get; set; }
    public string? Model { get; set; }
    public int? GoodsCodeId { get; set; }

    [Required(ErrorMessage = "Marka alanı zorunludur.")]
    public string Brand { get; set; }
    public double? Quantity { get; set; }

    public int? UnitId { get; set; }
    public bool Variant { get; set; }
    public string? VariantDescription { get; set; }

    [Required(ErrorMessage = "Kategori alanı zorunludur.")]
    public int StockCategoryId { get; set; }

    public MinControl? MinControl { get; set; }
    public int? MinStock { get; set; }
    public MaxControl? MaxControl { get; set; }
    public int? MaxStock { get; set; }
    public int? PurchaseVatId { get; set; }
    public int? SaleVatId { get; set; }
    public int? BuyingWithholdingRateId { get; set; }
    public int? SalesWithholdingRateId { get; set; }
    public int? BuyingWithholdingTypeId { get; set; }
    public int? SalesWithholdingTypeId { get; set; }
    public decimal? BuyingDiscountRate { get; set; }
    public decimal? SaleDiscountRate { get; set; }
    public bool Buyable { get; set; }
    public bool Saleable { get; set; }
    public int? EDocumentBaseRateId { get; set; }
    public bool IsActive { get; set; }
    public List<Stock> Stocks { get; set; }
    public List<IFormFile>? StockImage { get; set; }
}