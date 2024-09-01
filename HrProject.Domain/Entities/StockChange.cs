using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class StockSub : BaseEntity
    {
        public string Aciklama { get; set; }
        public int? EntryWareHouseId { get; set; }
        public WareHouse EntryWareHouse { get; set; }
        public int? ExitWareHouseId { get; set; }
        public WareHouse ExitWareHouse { get; set; }
        public DateTime DateChange { get; set; }
        public Person TeslimEden { get; set; }
        public int? TeslimEdenId { get; set; }
        public Person TeslimAlan { get; set; }
        public int? TeslimAlanId { get; set; }
        public List<StockChange> StockChanges { get; set; }
        public StockChangeEnum StockChangeEnum { get; set; }
    }
    public class StockChange : BaseEntity
    {
        public int? StockSubId { get; set; }
        public StockSub StockSub { get; set; }
        public int? InvoiceStockId { get; set; }
        public InvoiceStock InvoiceStock { get; set; }
        public int StockId { get; set; }
        public Stock Stock { get; set; }
        public int? OutWaybill2Id { get; set; }
        public OutWaybill2 OutWaybill2 { get; set; }
        public int? InWaybillId { get; set; }
        public InWaybill InWaybill { get; set; }
        public int? EntryWareHouseId { get; set; }
        public WareHouse EntryWareHouse { get; set; }
        public int? ExitWareHouseId { get; set; }
        public WareHouse ExitWareHouse { get; set; }
        public decimal Quantity { get; set; }
        public string? UnitType { get; set; }
        public StockChangeEnum StockChangeEnum { get; set; }
        public DateTime DateChange { get; set; }
        public string? Description { get; set; }

    }
}
