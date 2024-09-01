using HrProject.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace HrProject.Presentation.ViewModels
{
    public class WareHouseViewModel
    {
        public IEnumerable<WareHouse> WareHouses { get; set; }

        [Required(ErrorMessage = "Depo adı alanı zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Depo kodu alanı zorunludur.")]
        public string Code { get; set; }

        public string? Description { get; set; }
    }
}
