using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class Pattern : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Length { get; set; }
        public decimal Genislik { get; set; }
        public bool IsActive { get; set; }
        public bool IsMulti { get; set; }
        public int MaxQun { get; set; }
        public int GapCm { get; set; }
        public PatternType PatternType { get; set; }
        public List<PatternProjectElementType> PatternProjectElementTypes { get; set; }

    }
    public class PatternProjectElementType : BaseEntity
    {
        public int PatternId { get; set; }
        public Pattern Pattern { get; set; }

        public int ProjectElementTypeId { get; set; }
        public ProjectElementType ProjectElementType { get; set; }
    }
    public enum PatternType
    {
        Kolon,
        CatiMakasi,
        TaliKiris,
        DosemeKirisi,
        VincKirisi,
        OlukKirisi,
        AsikKirisi,
        TTDoseme,
        BoslukluDoseme
    }
}
