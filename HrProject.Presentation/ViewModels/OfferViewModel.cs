using System.ComponentModel.DataAnnotations;

namespace HrProject.Presentation.ViewModels
{
    public class OfferViewModel
    {
        [Required(ErrorMessage = "Açık Adres alanı zorunludur.")]
        public string Adress { get; set; }

        public string? Explanation { get; set; }

        [Required(ErrorMessage = "Parsel Numarası alanı zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Parsel Numarası sadece pozitif tamsayı olmalıdır.")]
        public int PlotNumber { get; set; }

        public string ParcelNumber { get; set; }

        [Required(ErrorMessage = "Şehir seçimi zorunludur.")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "İlçe seçimi zorunludur.")]
        public int DistrictId { get; set; }

        [Required(ErrorMessage = "Mahalle seçimi zorunludur.")]
        public int NeighbourhoodId { get; set; }
        public IFormFile FirstDraw { get; set; }
        // [Required(ErrorMessage = "Kullanıcı alanı zorunludur.")]
        public string ApplicationUserId { get; set; }
        [Required(ErrorMessage = "Ad Zorunludur.")]
        [RegularExpression("^[a-zA-Z0-9_ ()]*$", ErrorMessage = "Ad sadece harf, rakam, boşluk, parantez ve alt çizgi içerebilir.")]
        public string Name { get; set; }
        public string Code { get; set; }
        public int CariKartId { get; set; }
        public DateTime? LengthOfTerm { get; set; }

    }
    public class OfferViewModelMobile
    {
        [Required(ErrorMessage = "Açık Adres alanı zorunludur.")]
        public string Adress { get; set; }

        public string? Explanation { get; set; }

        [Required(ErrorMessage = "Parsel Numarası alanı zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "Parsel Numarası sadece pozitif tamsayı olmalıdır.")]
        public int PlotNumber { get; set; }

        public string ParcelNumber { get; set; }

        [Required(ErrorMessage = "Şehir seçimi zorunludur.")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "İlçe seçimi zorunludur.")]
        public int DistrictId { get; set; }

        [Required(ErrorMessage = "Mahalle seçimi zorunludur.")]
        public int NeighbourhoodId { get; set; }
        public string FirstDraw { get; set; }
        public string FirstDrawUzanti { get; set; }
        public string FirstDrawFileName { get; set; }
        public string ApplicationUserId { get; set; }
        [Required(ErrorMessage = "Ad Zorunludur.")]
        [RegularExpression("^[a-zA-Z0-9_ ()]*$", ErrorMessage = "Ad sadece harf, rakam, boşluk, parantez ve alt çizgi içerebilir.")]
        public string Name { get; set; }
        public string Code { get; set; }
        public int CariKartId { get; set; }
        public DateTime? LengthOfTerm { get; set; }

    }
}
