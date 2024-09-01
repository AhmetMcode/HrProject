using System;
namespace HrProject.Presentation.ViewModels
{
    public class ListStockChangeViewModel
    {
        public string Name { get; set; }
        public string StockChangeType { get; set; }
        public DateTime DateChange { get; set; }
        public string EntryWareHouse { get; set; }
        public string ExitWareHouse { get; set; }
        public decimal Quantity { get; set; }
        public string UnitType { get; set; }
        public string CustomerName { get; set; }
        public string RecordedBy { get; set; }
        public string ActionType { get; set; }

    }
}

