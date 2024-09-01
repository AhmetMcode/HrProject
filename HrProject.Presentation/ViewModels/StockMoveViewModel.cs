using HrProject.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace HrProject.Presentation.ViewModels
{
    public class StockMoveViewModel
    {
        public IEnumerable<StockMove> StockMoves { get; set; }
        [Required(ErrorMessage = "Depo Adı alanı zorunludur.")]

        public int WareHouseId { get; set; }
        public int GoodsCodeId { get; set; }
        public string StockName { get; set; }
        [Required(ErrorMessage = "Başlangıç Tarihi alanı zorunludur.")]
        public DateTime EntryDate { get; set; }
        [Required(ErrorMessage = "Bitiş Tarihi alanı zorunludur.")]

        public DateTime ExitDate { get; set; }
        public string? Description { get; set; }
    }
}
