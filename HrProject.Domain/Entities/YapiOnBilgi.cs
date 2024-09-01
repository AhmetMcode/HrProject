using HrProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Domain.Entities
{
    public class YapiOnBilgi : BaseEntity
    {
        public string? IletisimBilgileri { get; set; }
        public string? FirmaYetkiliAdSoyad { get; set; }
        public string? Adres { get; set; }

        public string? Adaparserel { get; set; }
        public bool VincKirisiVarMi { get; set; }
        public bool IlerıyeDonukVincKirisiVarMi { get; set; }
        public string VincKirisiMaxAgirlik { get; set; }

        public bool TesviYapılacakMi { get; set; }
        public bool CatidaIlaveYukVarMi { get; set; }

        public bool ArakatHareketliYükVarMi { get; set; }
        public bool CatiFeneriVarMi { get; set; }

        public bool MimariProjeVarMi { get; set; }
        public string? MimariIletisimBilgileri { get; set; }

        public string? DiğerBilgiler { get; set; }

    }
}
