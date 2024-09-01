using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class ProjectModuleSub : BaseEntity
    {
        public bool UretimOnay { get; set; }
        public string? UretimOnayBelge { get; set; }
        public string? UretimOnayBelgeUzanti { get; set; }
        public string? UretimOnayBelgeAd { get; set; }
        public string? KullanimAd { get; set; }
        public bool PlaningStart { get; set; }
        public bool PlaningStop { get; set; }
        public string Name { get; set; }
        public bool StartProject { get; set; }
        public bool StopProject { get; set; }
        public string? StopProjectDesc { get; set; }
        public DateTime StartProjectTime { get; set; }
        public DateTime LastMailSendTime { get; set; }
        public DateTime MailSendTime { get; set; }
        public DateTime ProjeTerminTarihi { get; set; }
        public string? CustomerRequest { get; set; }
        public string? ArchProject { get; set; }
        public string? GroundReport { get; set; }
        public string? PozNumber { get; set; }
        public int OfferId { get; set; }
        public Offer Offer { get; set; }
        public List<ProjectModuleStatus> ProjectModuleStatus { get; set; }
        public List<ProductionDrawing> ProductionDrawings { get; set; }
    }
    public class ProjectModuleStatus : BaseEntity
    {
        public int ProjectModuleSubId { get; set; }
        public ProjectModuleSub ProjectModuleSub { get; set; }
        public ProjectProcessStage ProjectProcessStage { get; set; }
        public SubStage SubStage { get; set; }
        public ApplicationUser RecipentUser { get; set; }
        public string? RecipentUserId { get; set; }
        public ApplicationUser ResponsibleUser { get; set; }
        public string? ResponsibleUserId { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompleteDate { get; set; }
    }
    public class ProductionDrawing : BaseEntity
    {
        public int ProjectModuleSubId { get; set; }
        public ProjectModuleSub ProjectModuleSub { get; set; }
        public string StageName { get; set; }
        public SubStage SubStage { get; set; }
        public ApplicationUser RecipentUser { get; set; }
        public string? RecipentUserId { get; set; }
        public ApplicationUser ResponsibleUser { get; set; }
        public string? ResponsibleUserId { get; set; }
        public DateTime FinishDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompleteDate { get; set; }
    }

    public class UretimOnayLog : BaseEntity
    {
        public DateTime GonderimZamani { get; set; }
        public string Icerik { get; set; }
        public string? Tel { get; set; }
        public string? Mail { get; set; }
        public bool UretimOnay { get; set; }
        public int ProjectModuleSubId { get; set; }
        public ProjectModuleSub ProjectModuleSub { get; set; }
    }

}
