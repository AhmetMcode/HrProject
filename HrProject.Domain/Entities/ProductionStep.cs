using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class ProductionStep : BaseEntity
    {
        public int? QualityFormSubId { get; set; }
        public QualityFormSub QualityFormSub { get; set; }
        public ManifactStepType ManifactStepType { get; set; }
        public int ManifactStepTypeId { get; set; }
        public bool LastStep { get; set; }
        public string Name { get; set; }
        public int DurationInMinutes { get; set; }
        public bool IsQuality { get; set; }
        public bool Kalite { get; set; }
        public bool Uretim { get; set; }
        public bool SadeceOnay { get; set; }
        public ProductStepEnum ProductStepEnum { get; set; }

    }

}
