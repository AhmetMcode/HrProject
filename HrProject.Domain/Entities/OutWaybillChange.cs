using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class OutWaybillChange : BaseEntity
    {
        public int StockId { get; set; }
        public Stock Stock { get; set; }
        public int WareHouseId { get; set; }
        public WareHouse WareHouse { get; set; }
        public double Quantity { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
    }
}
