using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class PersonMounthPayment : BaseEntity
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Maas { get; set; }
        public decimal CalismasiGereken { get; set; }
        public decimal CalisilanSaat { get; set; }
        public decimal TotalMesai { get; set; }
        public DateTime Ay { get; set; } // Ait olduğu ay
        public decimal BrutUcret { get; set; } // Brüt ücret
        public decimal IkramiyePrimFazlaMesai { get; set; } // İkramiye, prim, fazla mesai vb.
        public decimal GelirVergisiIndirimi { get; set; } // Gelir vergisi indirimi
        public decimal SgkMatrahi { get; set; } // SGK matrahı
        public decimal SgkKesintisi { get; set; } // SGK kesintisi
        public decimal IssizlikSigortasi { get; set; } // İşsizlik sigortası
        public decimal BesKesintisi { get; set; } // Bireysel emeklilik (BES) kesintisi
        public decimal DigerKesintiler { get; set; } // Diğer kesintiler
        public decimal VergiMatrahi { get; set; } // Vergi matrahı
        public decimal KumuleVergiMatrahi { get; set; } // Kümüle vergi matrahı
        public decimal GelirVergisi { get; set; } // Gelir vergisi
        public decimal OrtalamaGelirVergisiOrani { get; set; } // Ortalama gelir vergisi oranı
        public decimal DamgaVergisi { get; set; } // Damga vergisi
        public decimal NetUcret { get; set; } // Net ücret

    }
}
