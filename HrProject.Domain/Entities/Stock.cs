using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class Stock : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string? Barcode { get; set; }
        public string? Description { get; set; }
        public string? Model { get; set; }
        public int? GoodsCodeId { get; set; }
        public GoodsCode GoodsCode { get; set; }
        public string Brand { get; set; }
        public double? Quantity { get; set; }
        public int? UnitId { get; set; }
        public Unit Unit { get; set; }
        public bool Variant { get; set; }
        public string? VariantDescription { get; set; }
        public int StockCategoryId { get; set; }
        public StockCategory StockCategory { get; set; }
        public bool IsActive { get; set; }
        public MinControl? MinControl { get; set; }
        public int? MinStock { get; set; }
        public MaxControl? MaxControl { get; set; }
        public int? MaxStock { get; set; }
        public int? PurchaseVatId { get; set; }
        public PurchaseVat PurchaseVat { get; set; }
        public int? SaleVatId { get; set; }
        public SaleVat SaleVat { get; set; }
        public int? BuyingWithholdingRateId { get; set; }
        public BuyingWithholdingRate? BuyingWithholdingRate { get; set; }
        public int? SalesWithholdingRateId { get; set; }
        public SalesWithholdingRate? SalesWithholdingRate { get; set; }
        public int? BuyingWithholdingTypeId { get; set; }
        public BuyingWithholdingType? BuyingWithholdingType { get; set; }
        public int? SalesWithholdingTypeId { get; set; }
        public SalesWithholdingType? SalesWithholdingType { get; set; }
        public decimal? BuyingDiscountRate { get; set; }
        public decimal? SaleDiscountRate { get; set; }
        public bool Buyable { get; set; }
        public bool Saleable { get; set; }
        public int? EDocumentBaseRateId { get; set; }
        public EDocumentBaseRate? EDocumentBaseRate { get; set; }
        public List<StockChange> StockChanges { get; set; }
        public List<StockImage> StockImages { get; set; }
    }
    public class StockUnit : BaseEntity
    {
        public int StockId { get; set; }
        public Stock Stock { get; set; }
        public Unit Unit { get; set; }
        public int UnitId { get; set; }
        public bool IsDefault { get; set; }
        public decimal Carpan { get; set; }
    }

    public class StockImage : BaseEntity
    {
        public int StockId { get; set; }
        public Stock Stock { get; set; }
        public string ImagePath { get; set; }  // Resmin sunucuda saklandığı yol
    }
}