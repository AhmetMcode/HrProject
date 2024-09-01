using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class FuelTransfer : BaseEntity
    {
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public string FuelType { get; set; }
        public string MainResponsible { get; set; }
        public decimal LastKm { get; set; }
        public decimal FuelAmount { get; set; }
        public DateTime FuelTransferDAte { get; set; }
        public string? Description { get; set; }
        public int StockId { get; set; }
        public string? StockName { get; set; }
    }
}
