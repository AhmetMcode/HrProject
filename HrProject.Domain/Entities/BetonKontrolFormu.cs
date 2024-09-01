using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class BetonKontrolFormuSub : BaseEntity
    {

        public BetonDemirTipi BetonDemirTipi { get; set; }
        public string ProductManifact2IdS { get; set; }
        public ProductManifact2 ProductManifact2 { get; set; }
        public string? ManifactDesc { get; set; }
        public string? ControlDesc { get; set; }
        public string? LastControlDesc { get; set; }
        public int? GermePersonId { get; set; }
        public Person GermePerson { get; set; }
        public int? UretimPersonId { get; set; }
        public Person UretimPerson { get; set; }
        public int? ControlPersonId { get; set; }
        public Person ControlPerson { get; set; }
        public int? LastControlPersonId { get; set; }
        public Person LastControlPerson { get; set; }
    }
    public class BetonKontrolFormuSorulari : BaseEntity
    {
        public int SiraNo { get; set; }
        public string Soru { get; set; }
        public QuestionType SoruTipi { get; set; }
    }
    public class BetonKontrolFormuCevaplari : BaseEntity
    {
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public AnswerType? AnswerType { get; set; }
        public string? Answer { get; set; }
        public string? Aciklama { get; set; }
    }
    public enum BetonDemirTipi
    {
        Beton = 0,
        Demir = 1,
        Diger = 2,
    }
}
