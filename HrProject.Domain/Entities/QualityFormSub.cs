using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class QualityFormSub : BaseEntity
    {
        public BetonDemirTipi BetonDemirTipi { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public List<Question> Questions { get; set; }
    }

    public class Question : BaseEntity
    {
        public QualityFormSub QualityFormSub { get; set; }
        public int QualityFormSubId { get; set; }
        public int OrderNumber { get; set; }
        public string QuestionDesc { get; set; }
        public QuestionType QuestionType { get; set; }
    }
    public class QualityFormSubAnswer : BaseEntity
    {
        public QualityFormFinalType QualityFormFinalType { get; set; }
        public int QualityFormSubId { get; set; }
        public QualityFormSub QualityFormSub { get; set; }
        public string? DokumanTarihi { get; set; }
        public string? DokumanNo { get; set; }
        public string? ElemanAdi { get; set; }
        public string? MusteriAdi { get; set; }
        public string? KalipNo { get; set; }
        public string? DonatiSinifi { get; set; }
        public string? UrunAdedi { get; set; }
        public string? ManifactDesc { get; set; }
        public string? ControlDesc { get; set; }
        public string? LastControlDesc { get; set; }
        public int? GermePersonId { get; set; }
        public string ProductManifactsId { get; set; }
        public string? ProductManifactsDetailsId { get; set; }
        public string? UrunlerId { get; set; }
        public Person GermePerson { get; set; }
        public int? UretimPersonId { get; set; }
        public Person UretimPerson { get; set; }
        public int? ControlPersonId { get; set; }
        public Person ControlPerson { get; set; }
        public int? LastControlPersonId { get; set; }
        public Person LastControlPerson { get; set; }
        public List<QuestionAnswer> QuestionAnswers { get; set; }

    }
    public class QuestionAnswer : BaseEntity
    {
        public QualityFormSubAnswer QualityFormSubAnswer { get; set; }
        public int QualityFormSubAnswerId { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public AnswerType? AnswerType { get; set; }
        public AnswerType? IlkKontrolCevap { get; set; }
        public AnswerType? SonKontrolCevap { get; set; }
        public string? Desc { get; set; }
        public AnswerCategory AnswerCategory { get; set; }
    }
    public enum AnswerCategory
    {
        Uretim,
        Kalite,
        Son
    }
    public enum QuestionType
    {
        All = 0,
        Rules = 1,
    }
    public enum AnswerType
    {
        Uygun = 0,
        UygunDegil = 1,
        MevcutDegil = 2,
        Duzeltildi = 3,
        Duzeltilemedi = 4,
    }
    public enum QualityFormFinalType
    {
        Uygun = 0,
        UygunDegil = 1,
        Revize = 2,
        Zaiyat = 3,
        Baslanmadi = 4,
    }
}
