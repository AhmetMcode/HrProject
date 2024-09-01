using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class GetWareHouseStocksVm
    {
        public Stock Stock { get; set; }
        public WareHouse WareHouse { get; set; }
        public decimal Quantity { get; set; }
    }
}
