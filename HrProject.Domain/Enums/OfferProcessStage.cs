namespace HrProject.Domain.Enums
{
    public enum OfferProcessStage
    {
        Eklendi = 0,
        AtamaYapildi = 1,
        // DrawingFirst = 2,
        CizimYapildi = 3,
        HesapYapiliyor = 4,
        //Calculated = 5 ,
        YoneticiOnayinaGonderildi = 6,
        YoneticiOnayladi = 7,
        MusteriBekleniyor = 8,
        MuseteriKabul = 9,
        MusteriRed = 10,
        Sozlesme = 11,
    }
    public enum ProjectProcessStage
    {
        ProjeOlusturuldu,
        MusteriOnayıAlındı,
        StatikHesap,
        Modelleme,
        MimariProje,
        BirinciOnay,
        IkinciOnay,
        RuhsatProjesi,
        Metraj,
        BilgiKartı,
        UretimeBaslandi,
    }
    public enum SubStage
    {
        None = 0,
        Start = 1,
        Finish = 2,
        Revization = 3,
    }
}
