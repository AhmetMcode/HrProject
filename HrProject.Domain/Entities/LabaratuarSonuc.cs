using HrProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Domain.Entities
{
    public class LabaratuarSonuc : BaseEntity
    {
        public ProductPlanDailyPlanned ProductPlanDailyPlanned { get; set; }
        public int ProductPlanDailyPlannedId { get; set; }

        public decimal BirinciSonuc { get; set; }
        public string? BirinciSonucAciklama { get; set; }

        public decimal IkınciSonuc { get; set; }
        public string? IkınciSonucAciklama { get; set; }

        public decimal YediGunSonuc { get; set; }
        public string? YediGunSonucAciklama { get; set; }

        public decimal YirmiBirGunSonuc { get; set; }
        public string? YirmiBirGunSonucAciklama { get; set; }

        public decimal YirmiSekizGunSonuc { get; set; }
        public string? YirmiSekizGunSonucAciklama { get; set; }

        public bool SokumOnay { get; set; }
        public string? SokumOnayAciklama { get; set; }
    }
}
