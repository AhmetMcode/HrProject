using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class FuelTransferViewModel
    {
        public IEnumerable<FuelTransfer> FuelTransfers { get; set; }
        public FuelTransfer FuelTransfer { get; set; }
        public int VehicleId { get; set; }
        public string FuelType { get; set; }
        public string MainResponsible { get; set; }
        public decimal LastKm { get; set; }
        public decimal FuelAmount { get; set; }
        public DateTime FuelTransferDAte { get; set; }
        public string? Description { get; set; }
        public int stocksId { get; set; }
        public string? StockName { get; set; }
    }
}
