using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class InfoCompany : BaseEntity
    {
        public string? Resim { get; set; }
        public string? FaturaHarf { get; set; }
        public string? EArsivHarf { get; set; }
        public string? Unvan { get; set; }
        public string? YetkiliAdSoyad { get; set; }
        public string? VKN_TCKN { get; set; }
        public string? VergiDairesi { get; set; }
        public string? TicaretSicilNo { get; set; }
        public string? CaddeSokakBulvar { get; set; }
        public string? KapiNo { get; set; }
        public string? BinaNo { get; set; }
        public string? Telefon { get; set; }
        public string? WebAdres { get; set; }
        public string? IlceSemtMahalle { get; set; }
        public string? Sehir { get; set; }
        public string? Ulke { get; set; }
        public string? SirketAdresi { get; set; }
    }
}
