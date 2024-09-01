using HrProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Domain.Entities
{
    public class KaliteBirimAtama : BaseEntity
    {
        public int ProductionPlaceId { get; set; }
        public ProductionPlace ProductionPlace { get; set; }

        public ICollection<KaliteBirimAtamaIlkKontrolUser> IlkKontrolUsers { get; set; }
        public ICollection<KaliteBirimAtamaSonKontrolUser> SonKontrolUsers { get; set; }
    }
    public class KaliteBirimAtamaIlkKontrolUser : BaseEntity
    {
        public int KaliteBirimAtamaId { get; set; }
        public KaliteBirimAtama KaliteBirimAtama { get; set; }
        public string IlkKontrolUserId { get; set; }
        public string? aciklama { get; set; }
        public ApplicationUser IlkKontrolUser { get; set; }
    }

    public class KaliteBirimAtamaSonKontrolUser : BaseEntity
    {
        public int KaliteBirimAtamaId { get; set; }
        public KaliteBirimAtama KaliteBirimAtama { get; set; }
        public string SonKontrolUserId { get; set; }
        public ApplicationUser SonKontrolUser { get; set; }
    }


}
