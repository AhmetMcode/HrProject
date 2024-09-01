using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HrProject.Presentation.ViewModels
{
    public class PersonCreateVM
    {
        [Required]
        public decimal WorkingTime { get; set; }
        [Required]

        public decimal MesaiCarpan { get; set; }
        [Required]
        public string TcNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string IBAN { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        public int PersonPositionId { get; set; }
        public List<SelectListItem> PositionsList { get; set; }
        [Required]
        public int WorkplaceId { get; set; }
        public List<SelectListItem> WorkPlaceList { get; set; }
        [Required]
        public DateTime EntryDate { get; set; } = DateTime.Now;
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public IFormFile IdCard { get; set; }
        [Required]
        public IFormFile PlaceOfResidence { get; set; }

        public IFormFile ProfilePicture { get; set; }
        [Required]
        public IFormFile Diploma { get; set; }
        [Required]
        public IFormFile CriminalRecord { get; set; }
        [Required]
        public IFormFile PopulationRegistration { get; set; }
        [Required]
        public IFormFile HealthReport { get; set; }
        [Required]
        public DateTime Birthdate { get; set; } = new DateTime(1980, 1, 1);

    }
}
