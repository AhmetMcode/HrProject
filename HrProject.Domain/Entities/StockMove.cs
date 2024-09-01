using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class StockMove : BaseEntity
    {
        public int WareHouseId { get; set; }
        public WareHouse WareHouse { get; set; }
        public int GoodsCodeId { get; set; }
        public GoodsCode GoodsCode { get; set; }
        public string StockName { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExitDate { get; set; }
        public string? Description { get; set; }
    }
}
