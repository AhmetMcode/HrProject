using HrProject.Domain.Entities;
using HrProject.Domain.Enums;

namespace HrProject.Presentation.ViewModels
{
    public class StockChangeViewModel
    {
        public IEnumerable<StockChange> StockChanges { get; set; }
        public int StockId { get; set; }
        public string? Barcode { get; set; }
        public string AcceptUserId { get; set; }
        public string AuthorizingUserId { get; set; }
        public int? EntryWareHouseId { get; set; }
        public int? ExitWareHouseId { get; set; }
        public DateTime DateChange { get; set; }
        public decimal Quantity { get; set; }
        public string UnitType { get; set; }
        public Unit Unit { get; set; }
        public StockChangeEnum SelectedStockChangeType { get; set; }
    }
}
