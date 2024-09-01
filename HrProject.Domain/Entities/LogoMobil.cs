using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class LogoMobil : BaseEntity
    {
        public string Name { get; set; }
        public string Fiyat { get; set; }
        public string Barcode { get; set; }
        public string Base64ImageData { get; set; }
    }
}
