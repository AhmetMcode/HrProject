using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IProjectModel : IBaseRepository<ProjectModuleSub>
    {
        public ProjectModuleSub AddAndListProjectModuleSub(int offerId);
        public ProjectModuleSub GetByOfferId(int offerId);
        public ProjectModuleSub GetProjectByIdInclude(int id);
        public List<ProjectModuleSub> GetProjectsInclude();
        public List<ProjectModuleSub> GetProjects();
        public List<ProjectModuleSub> GetProjectsUretimeBaslanan();
        public List<ProjectModuleStatus> GetProjectsStatusByProjectId(int subId);
        public List<ProductionDrawing> GetProductionDrawings(int subId);
        public List<ProductionDrawing> GetProductionDrawingByUserId(string userId);
        public void AddProductionDrawing(int subId, int id, string name, string reciepntId, string responsUserId, DateTime Start, DateTime Finish);
        public List<ProjectModuleStatus> GetProjectsStatusByUserId(string userId);
        public List<ProjectModuleStatus> GetProjectsStatusAll();
        public List<PmCalculate> GetPmCalculates(int id);
        public List<PmCalculate> GetPmCalculatesAll();
        public List<PmCalculate> GetPmCalculatesByPlanStart();
        public PmCalculate GetPmCalculateByOne(int id);
        public string SavePmCalculate(PmCalculate pmCalculate);
        public List<PMProjectElementDetails> GetProjectDetail(int id);
        List<PMWickerIronCalculate> GetWickerIronCalculate(int PmCalculateId);
        public void StartProject(int id);
        public string FinishTask(int id, string userId);
        public void InsertFileLog(FileUploadLog log);
        public bool FileUploadThisUser(string fileName, string filePath, string userId);
        public void SavePmCalculates(List<PmCalculate> pmCalculates);
        public void UpdateHesapDoneleri(string userId, int subId);
        public void DeleteCalculate(int id);
        public void SaveProjectDetail(PMProjectElementDetails projectElementDetails, decimal netIron, decimal netIronTotal, decimal concrete, decimal concreteTotal);
        public ProjectModuleStatus StartTask(int id);
        public void SaveProjectAssigment(List<FormModel> formModels);
        List<PmRopeIron> GetRopeIrons(int calculateId);
        List<PmAnkrajIron> GetAnkrajIrons(int calculateId);
        List<KeyValuePair<int, decimal>> GetTotalConcretsAllProjects();
        List<KeyValuePair<int, decimal>> GetTotalUretilen();
        public ProjectElement GetProjectElement(string code);
        public ProjectElementType GetProjectElementTypeByName(string name, int projectElementId);

    }
}
