using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class StockPast : BaseEntity
    {
        public string MoveType { get; set; }

        public int StockChangeId { get; set; }
        public StockChange StockChange { get; set; }

        public int OutWaybill2Id { get; set; }
        public OutWaybill2 OutWaybill2 { get; set; }

        public int InWaybillId { get; set; }
        public InWaybill InWaybill { get; set; }

    }
}
