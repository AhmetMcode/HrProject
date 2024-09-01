using System;
namespace HrProject.Presentation.ViewModels
{
    public class StartStockCountViewModel
    {
        public int SelectedWarehouseId { get; set; }
    }

    public class StockCountViewModel
    {
        public int SubSayimId { get; set; }
        public int WareHouseId { get; set; }
        public string WareHouseName { get; set; }
        public DateTime SayimTime { get; set; }
        public string UserName { get; set; } // Assuming you want to display the user who started the count
        public bool IsSayimCompleted { get; set; }
        public List<StockCountDetailViewModel> StockCountDetails { get; set; }
    }

    public class StockCountDetailViewModel
    {
        public int StockId { get; set; }
        public string StockName { get; set; }
        public string StockCode { get; set; }
        public string Barcode { get; set; }
        public double? CurrentQuantity { get; set; }
        public string UnitName { get; set; }
        public string StockCategoryName { get; set; }
        public double CountedQuantity { get; set; } // Quantity entered by the user
    }

    public class SaveStockCountViewModel
    {
        public int SubSayimId { get; set; }
        public StockCountDetailViewModel StockDetail { get; set; } // Changed property name for consistency
    }
}

