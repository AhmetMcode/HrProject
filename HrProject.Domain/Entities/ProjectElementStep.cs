using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class ProjectElementStep : BaseEntity
    {
        public int ProjectElementId { get; set; }
        public ProjectElement ProjectElement { get; set; }
        public int ProductionStepId { get; set; }
        public ProductionStep ProductionStep { get; set; }
        public int Sequence { get; set; } // Sıra numarası
        public bool IsQuality { get; set; }
        public bool LastStep { get; set; }
    }
}
