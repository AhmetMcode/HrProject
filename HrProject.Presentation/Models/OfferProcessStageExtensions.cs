using HrProject.Domain.Enums;

namespace HrProject.Presentation.Models
{
    public static class OfferProcessStageExtensions
    {
        private static Dictionary<OfferProcessStage, string> offerProcessStageTurkishNames = new Dictionary<OfferProcessStage, string>
    {
        { OfferProcessStage.Eklendi, "Teklif Sisteme Eklendi" },
        { OfferProcessStage.AtamaYapildi, "Atama Yapildi Cizim Bekliyor" },
        { OfferProcessStage.CizimYapildi, "Cizim Yapildi Hesaba Baslandi" },
        { OfferProcessStage.HesapYapiliyor, "Hesab Yapildi Onay Bekliyor " },
        { OfferProcessStage.YoneticiOnayinaGonderildi, "Yönetici Onayı Bekleniyor" },
        { OfferProcessStage.YoneticiOnayladi, "Yönetici Onayladı Musteriye Gonderilmeyi Bekliyor" },
        { OfferProcessStage.MusteriBekleniyor, "Müşteri Bekleniyor" },
        { OfferProcessStage.MuseteriKabul, "Müşteri Onayladı" },
        { OfferProcessStage.MusteriRed, "Müşteri Geri Çevirdi" },
        { OfferProcessStage.Sozlesme, "Sözleşme" }
    };

        public static string ToTurkishString(this OfferProcessStage stage)
        {
            if (offerProcessStageTurkishNames.ContainsKey(stage))
            {
                return offerProcessStageTurkishNames[stage];
            }
            return stage.ToString();
        }
    }

    public static class ProjectProcessStageExtensions
    {
        private static Dictionary<ProjectProcessStage, string> projectProcessStageTurkishNames = new Dictionary<ProjectProcessStage, string>
    {
        { ProjectProcessStage.ProjeOlusturuldu, "İş Ataması Yapıldı" },
        { ProjectProcessStage.MusteriOnayıAlındı, "Hesap Donelerinin İletilmesi" },
        { ProjectProcessStage.StatikHesap, "Statik Hesap" },
        { ProjectProcessStage.Modelleme, "Modelleme" },
        { ProjectProcessStage.MimariProje, "Üretim Çizimleri" },
        { ProjectProcessStage.BirinciOnay, "Birinci Kontrol" },
        { ProjectProcessStage.IkinciOnay, "İkinci Kontrol" },
        { ProjectProcessStage.RuhsatProjesi, "Ruhsat Projesi" },
        { ProjectProcessStage.Metraj, "Metraj" },
        { ProjectProcessStage.BilgiKartı, "Bilgi Kartı" },
        { ProjectProcessStage.UretimeBaslandi, "Üretime Gönderildi" },
    };

        public static string ToTurkishString(this ProjectProcessStage stage)
        {
            if (projectProcessStageTurkishNames.ContainsKey(stage))
            {
                return projectProcessStageTurkishNames[stage];
            }
            return stage.ToString();
        }
    }
    public static class SubStageExtensions
    {
        private static Dictionary<SubStage, string> subStageTurkishNames = new Dictionary<SubStage, string>
    {
        { SubStage.None, "Başlanmadı" },
        { SubStage.Start, "Süreç Başladı" },
        { SubStage.Finish, "Süreç Bitirildi" },
        { SubStage.Revization, "Revizyon" },
    };

        public static string ToTurkishString(this SubStage subStage)
        {
            if (subStageTurkishNames.ContainsKey(subStage))
            {
                return subStageTurkishNames[subStage];
            }
            return subStage.ToString();
        }
    }


}
