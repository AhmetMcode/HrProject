using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Domain.Enums;
using HrProject.Presentation.Data;
using HrProject.Presentation.Data.Migrations;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class ProjectModelService : BaseRepository<ProjectModuleSub>, IProjectModel
    {
        private readonly INotificationService notificationService;
        private readonly IUserService userService;

        public ProjectModelService(DbContextOptions<ApplicationDbContext> options, INotificationService notificationService, IUserService userService) : base(options)
        {
            this.notificationService = notificationService;
            this.userService = userService;
        }

        public ProjectModuleSub AddAndListProjectModuleSub(int offerId)
        {
            var projectModule = _context.ProjectModuleSub.Where(x => x.OfferId == offerId).Include(x => x.ProjectModuleStatus).FirstOrDefault();
            var offer = _context.Offers.Where(x => x.Id == offerId).FirstOrDefault();
            if (projectModule == null)
            {
                ProjectModuleSub projectModuleSub = new ProjectModuleSub();
                projectModuleSub.Name = offer.Name;
                projectModuleSub.OfferId = offerId;
                _context.ProjectModuleSub.Add(projectModuleSub);
                _context.SaveChanges();
                foreach (ProjectProcessStage item in Enum.GetValues(typeof(ProjectProcessStage)))
                {
                    ProjectModuleStatus projectModuleStatus = new ProjectModuleStatus();
                    projectModuleStatus.ProjectModuleSubId = projectModuleSub.Id;
                    projectModuleStatus.ProjectProcessStage = item;
                    projectModuleStatus.SubStage = SubStage.None;
                    _context.ProjectModuleStatus.Add(projectModuleStatus);
                    _context.SaveChanges();
                }

                return _context.ProjectModuleSub.Where(x => x.OfferId == offerId).Include(x => x.ProjectModuleStatus).FirstOrDefault();
            }
            else if (projectModule.ProjectModuleStatus.Count == 0)
            {
                foreach (ProjectProcessStage item in Enum.GetValues(typeof(ProjectProcessStage)))
                {
                    ProjectModuleStatus projectModuleStatus = new ProjectModuleStatus();
                    projectModuleStatus.ProjectModuleSubId = projectModule.Id;
                    projectModuleStatus.ProjectProcessStage = item;
                    projectModuleStatus.SubStage = SubStage.None;
                    _context.ProjectModuleStatus.Add(projectModuleStatus);
                    _context.SaveChanges();
                }
            }
            return projectModule;


        }



        public void AddProductionDrawing(int subId, int id, string name, string reciepntId, string responsUserId, DateTime Start, DateTime Finish)
        {
            if (id != 0)
            {
                var productionDrawing = _context.ProductionDrawings.Where(x => x.Id == id).FirstOrDefault();
                if (productionDrawing != null)
                {
                    productionDrawing.StartDate = Start;
                    productionDrawing.FinishDate = Finish;
                    productionDrawing.RecipentUserId = reciepntId;
                    productionDrawing.StageName = name;
                    _context.ProductionDrawings.Update(productionDrawing);
                    _context.SaveChanges();
                }
            }
            else
            {
                var productionDrawing = new ProductionDrawing();
                productionDrawing.ProjectModuleSubId = subId;
                productionDrawing.StartDate = Start.Date;
                productionDrawing.FinishDate = Finish.Date;
                productionDrawing.CreationUserId = responsUserId;
                productionDrawing.StageName = name;
                _context.ProductionDrawings.Add(productionDrawing);
                _context.SaveChanges();
            }
        }

        public void DeleteCalculate(int id)
        {
            var asd = _context.PmCalculates.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(asd);
            _context.SaveChanges();
        }

        public bool FileUploadThisUser(string fileName, string filePath, string userId)
        {
            var asd = _context.FileUploadLog.Where(x => x.UploadFileName == fileName && x.UploadFolderName == filePath && x.UploadUserId == userId).FirstOrDefault();
            if (asd == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string FinishTask(int id, string userId)
        {
            var status = _context.ProjectModuleStatus
                .Where(x => x.Id == id)
                .Include(x => x.ProjectModuleSub)
                .FirstOrDefault();

            if (status != null)
            {
                if (status.ProjectProcessStage == ProjectProcessStage.StatikHesap ||
                    status.ProjectProcessStage == ProjectProcessStage.MimariProje ||
                    status.ProjectProcessStage == ProjectProcessStage.Modelleme)
                {
                    // Check if there is no record in FileUploadLog for the given user
                    var fileUploadLog = _context.FileUploadLog
                        .Where(x => x.UploadUserId == userId && x.ProjectModuleSubId == status.ProjectModuleSubId)
                        .FirstOrDefault();

                    if (fileUploadLog == null)
                    {
                        return "Hiç dosya yüklemediniz.";
                    }
                    else
                    {
                        // Update SubStage to SubStage.Finish
                        status.SubStage = SubStage.Finish;
                        _context.ProjectModuleStatus.Update(status);

                        _context.SaveChanges();

                        return "İşlem başarıyla tamamlandı.";
                    }
                }
                else
                {
                    if (status.ProjectProcessStage == ProjectProcessStage.IkinciOnay)
                    {
                        var status2 = _context.ProjectModuleStatus
                .Where(x => x.ProjectProcessStage == ProjectProcessStage.BirinciOnay && x.ProjectModuleSubId == status.ProjectModuleSubId)
                .Include(x => x.ProjectModuleSub)
                .FirstOrDefault();
                        if (status2.SubStage != SubStage.Finish)
                        {
                            return "Birinci Onay Tamamlanmadı";
                        }
                        else
                        {
                            status.SubStage = SubStage.Finish;
                            _context.ProjectModuleStatus.Update(status);
                            _context.SaveChanges();

                            return "İşlem başarıyla tamamlandı.";
                        }
                    }
                    else
                    {
                        status.SubStage = SubStage.Finish;
                        _context.ProjectModuleStatus.Update(status);
                        _context.SaveChanges();

                        return "İşlem başarıyla tamamlandı.";
                    }
                }
            }
            else
            {
                return "Belirtilen ID ile bir proje durumu bulunamadı.";
            }
        }

        public List<PmAnkrajIron> GetAnkrajIrons(int calculateId)
        {

            var result = _context.PmAnkrajIrons.Include(x => x.PmCalculate)
                                                .Where(x => x.PmCalculateId == calculateId).ToList();
            return result;
        }

        public ProjectModuleSub GetByOfferId(int offerId)
        {
            return _context.ProjectModuleSub.Where(x => x.OfferId == offerId).FirstOrDefault();
        }

        public PmCalculate GetPmCalculateByOne(int id)
        {
            var offerCalculate = _context.PmCalculates.Where(x => x.Id == id).Include(x => x.PmCalculateDocuments).Include(x => x.ProjectModuleSub).Include(x => x.ConcreteClass).FirstOrDefault();
            return offerCalculate;
        }

        public List<PmCalculate> GetPmCalculates(int id)
        {
            var offerCalculates = _context.PmCalculates.Where(x => x.ProjectModuleSubId == id).Include(x => x.ConcreteClass).Include(x => x.ProjectElement).Include(x => x.ProjectElementType).ToList();
            return offerCalculates;
        }

        public List<PmCalculate> GetPmCalculatesAll()
        {
            var offerCalculates = _context.PmCalculates.Include(x => x.ProjectModuleSub).Include(x => x.ConcreteClass).Include(x => x.ProjectElement).Include(x => x.ProjectElementType).ToList();
            return offerCalculates;
        }

        public List<PmCalculate> GetPmCalculatesByPlanStart()
        {
            var offerCalculates = _context.PmCalculates.Include(x => x.ProjectModuleSub).Include(x => x.ConcreteClass).Include(x => x.ProjectElement).Include(x => x.ProjectElementType).Where(x => x.ProjectModuleSub.PlaningStart == true).ToList();
            return offerCalculates;
        }

        public List<ProductionDrawing> GetProductionDrawingByUserId(string userId)
        {
            return _context.ProductionDrawings.Where(x => x.RecipentUserId == userId).Include(x => x.ProjectModuleSub).ThenInclude(x => x.Offer).ToList();
        }

        public List<ProductionDrawing> GetProductionDrawings(int subId)
        {
            return _context.ProductionDrawings.Where(x => x.ProjectModuleSubId == subId).Include(x => x.ResponsibleUser).Include(x => x.ProjectModuleSub).ToList();
        }

        public ProjectModuleSub GetProjectByIdInclude(int id)
        {
            return _context.ProjectModuleSub.Where(x => x.Id == id).Include(x => x.ProductionDrawings).Include(x => x.ProjectModuleStatus).ThenInclude(x => x.RecipentUser).FirstOrDefault();
        }

        public List<PMProjectElementDetails> GetProjectDetail(int id)
        {
            var result = _context.PMProjectElementDetails.Include(x => x.PmCalculate)
                                                  .Include(x => x.IronDiameterWeight)
                                                  .Where(x => x.PmCalculateId == id).ToList();
            return result;
        }

        public ProjectElement GetProjectElement(string code)
        {
            var result = _context.ProjectElements.Where(x => x.Code == code).FirstOrDefault();
            return result;
        }

        public ProjectElementType GetProjectElementTypeByName(string name, int projectElementId)
        {
            var result = _context.ProjectElementTypes.Where(x => x.Code == name && x.ProjectElementId == projectElementId).FirstOrDefault();
            if (result == null)
            {
                result = _context.ProjectElementTypes.Where(x => x.ProjectElementId == projectElementId).FirstOrDefault();
            }
            return result;
        }

        public List<ProjectModuleSub> GetProjects()
        {
            return _context.ProjectModuleSub
                           .Include(x => x.ProjectModuleStatus) // Include before Select
                           .Select(x => new ProjectModuleSub
                           {
                               Id = x.Id,
                               UretimOnay = x.UretimOnay,
                               UretimOnayBelgeUzanti = x.UretimOnayBelgeUzanti,
                               UretimOnayBelgeAd = x.UretimOnayBelgeAd,
                               KullanimAd = x.KullanimAd,
                               PlaningStart = x.PlaningStart,
                               PlaningStop = x.PlaningStop,
                               Name = x.Name,
                               StartProject = x.StartProject,
                               StopProject = x.StopProject,
                               StopProjectDesc = x.StopProjectDesc,
                               StartProjectTime = x.StartProjectTime,
                               LastMailSendTime = x.LastMailSendTime,
                               MailSendTime = x.MailSendTime,
                               ProjeTerminTarihi = x.ProjeTerminTarihi,
                               CustomerRequest = x.CustomerRequest,
                               ArchProject = x.ArchProject,
                               GroundReport = x.GroundReport,
                               PozNumber = x.PozNumber,
                               OfferId = x.OfferId,
                               ProjectModuleStatus = x.ProjectModuleStatus // Explicitly include related entity
                           })
                           .ToList();
        }


        public List<ProjectModuleSub> GetProjectsInclude()
        {
            return _context.ProjectModuleSub.Include(x => x.ProjectModuleStatus).Include(x => x.Offer).ThenInclude(x => x.CariKart).ToList();
        }

        public List<ProjectModuleStatus> GetProjectsStatusAll()
        {
            return _context.ProjectModuleStatus.Include(x => x.ResponsibleUser).Include(x => x.ProjectModuleSub).ThenInclude(x => x.Offer).ToList();
        }

        public List<ProjectModuleStatus> GetProjectsStatusByProjectId(int subId)
        {
            if (_context.ProjectModuleStatus.Where(x => x.ProjectModuleSubId == subId).Count() == 0)
            {

            }
            return _context.ProjectModuleStatus.Where(x => x.ProjectModuleSubId == subId).ToList();
        }

        public List<ProjectModuleStatus> GetProjectsStatusByUserId(string userId)
        {
            return _context.ProjectModuleStatus.Where(x => x.ResponsibleUserId == userId).Include(x => x.ProjectModuleSub).ThenInclude(x => x.Offer).ToList();
        }

        public List<ProjectModuleSub> GetProjectsUretimeBaslanan()
        {
            return _context.ProjectModuleSub
                .Where(x => x.UretimOnay == true)
                .ToList();
        }

        public List<PmRopeIron> GetRopeIrons(int calculateId)
        {
            var result = _context.PmRopeIrons.Include(x => x.PmCalculate)
                                                 .Include(x => x.ToronDiameter)
                                                 .Where(x => x.PmCalculateId == calculateId).ToList();
            return result;
        }

        public List<KeyValuePair<int, decimal>> GetTotalConcretsAllProjects()
        {
            var result = new List<KeyValuePair<int, decimal>>();

            var projects = _context.ProjectModuleSub.ToList();

            foreach (var proje in projects)
            {
                var pmCalculates = _context.PmCalculates.Where(x => x.ProjectModuleSubId == proje.Id).ToList();

                decimal totalGrossConcrete = 0;

                var offerCalculates = _context.PmCalculates
                    .Where(x => x.ProjectModuleSubId == proje.Id)
                    .ToList();

                var partTotalGrossConcrete = offerCalculates
                    .Sum(x => x.NetConcreteTotal ?? 0);
                totalGrossConcrete += partTotalGrossConcrete;
                result.Add(new KeyValuePair<int, decimal>(proje.Id, totalGrossConcrete));
            }
            return result;
        }

        public List<KeyValuePair<int, decimal>> GetTotalUretilen()
        {
            var result = new List<KeyValuePair<int, decimal>>();

            var projects = _context.ProjectModuleSub.ToList();

            foreach (var project in projects)
            {
                var pmCalculateIds = _context.PmCalculates.Where(x => x.ProjectModuleSubId == project.Id).ToList().Select(x => x.Id).ToList();
                var mcs = _context.ProductManifacts2
                                 .Include(x => x.ProductPlanProductPlanned)
                                     .ThenInclude(x => x.ProductPlanDailyPlanned)
                                         .ThenInclude(x => x.ProductPlanSubPlanned)
                                             .ThenInclude(x => x.PmCalculate)
                                 .Include(x => x.ProductPlanProductPlanned)
                                     .ThenInclude(x => x.ProductPlanDailyPlanned)
                                         .ThenInclude(x => x.ProductPlanSubPlanned)
                                             .ThenInclude(x => x.ProductPlan)
                                             .Include(x => x.ProductManifactDetail)
                                             .ThenInclude(x => x.ProjectElementStep)
                .ThenInclude(x => x.ProductionStep)
                                 .Where(x => pmCalculateIds.Contains((int)x.ProductPlanProductPlanned.ProductPlanDailyPlanned.ProductPlanSubPlanned.PmCalculateId))
                                 .Where(x => x.Uretildi == true)
                                 .ToList();

                decimal totalBetonHacmi = 0;

                foreach (var productManifact in mcs)
                {
                    // Ürünün beton hacmini hesapla: Ürünün üretilen adedi * ürünün beton miktarı
                    decimal betonHacmi = productManifact.ProductPlanProductPlanned.ProductPlanDailyPlanned.ProductPlanSubPlanned.PmCalculate.NetConcreteTotal ?? 0;

                    totalBetonHacmi += betonHacmi;
                }

                result.Add(new KeyValuePair<int, decimal>(project.Id, totalBetonHacmi));
            }

            return result;
        }

        public List<PMWickerIronCalculate> GetWickerIronCalculate(int PmCalculateId)
        {
            var result = _context.PMWickerIronCalculates.Include(x => x.PmCalculate)
                                                    .Include(x => x.SteelMeshType)
                                                    .Where(x => x.PmCalculateId == PmCalculateId).ToList();
            return result;
        }

        public void InsertFileLog(FileUploadLog log)
        {
            _context.FileUploadLog.Add(log);
            _context.SaveChanges();
        }

        public string SavePmCalculate(PmCalculate pmCalculate)
        {
            try
            {
                var pm = _context.PmCalculates.Where(x => x.ProjectModuleSubId == pmCalculate.ProjectModuleSubId && x.ElementCode == pmCalculate.ElementCode).FirstOrDefault();
                if (pm != null)
                {
                    pmCalculate.Id = pm.Id;
                    _context.PmCalculates.Update(pmCalculate);
                    _context.SaveChanges();
                }
                else
                {
                    _context.PmCalculates.Add(pmCalculate);
                    _context.SaveChanges();
                }

                return "işelem başarılı";
            }
            catch (Exception)
            {

                return "işelemde hata";
            }

        }

        public void SavePmCalculates(List<PmCalculate> pmCalculates)
        {
            foreach (var item in pmCalculates)
            {
                try
                {
                    if (item.Id != 0)
                    {
                        var calcualte = _context.PmCalculates.Where(x => x.Id == item.Id).FirstOrDefault();
                        calcualte.GrossConcrete = item.GrossConcrete;
                        calcualte.Price = item.Price;
                        calcualte.Length = item.Length;
                        calcualte.GrossConcreteTotal = item.GrossConcreteTotal * item.Price;
                        _context.PmCalculates.Update(calcualte);
                        _context.SaveChanges();
                    }
                    else
                    {
                        if (item.GrossConcrete == 0 || item.GrossConcrete == null)
                        {
                            continue;
                        }
                        var code = _context.PmCalculates.Where(x => x.ProjectModuleSubId == pmCalculates.FirstOrDefault().ProjectModuleSubId && x.ProjectElementId
                        == item.ProjectElementId).ToList().Count;
                        item.ElementCode = _context.ProjectElements.Where(x => x.Id == item.ProjectElementId).FirstOrDefault().Code + (code + 1);
                        _context.PmCalculates.Add(item);
                        _context.SaveChanges();

                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public async void SaveProjectAssigment(List<FormModel> formModels)
        {
            foreach (var item in formModels)
            {
                if (Enum.TryParse<ProjectProcessStage>(item.ProjectProcessStage, out ProjectProcessStage parsedEnumValue))
                {
                    // ProjectProcessStage itemProjectProcessStage = parsedEnumValue;
                    ProjectProcessStage itemProjectProcessStage = parsedEnumValue;
                    var projectModelSub = _context.ProjectModuleStatus.Where(x => x.ProjectModuleSubId == item.ProjectId && x.ProjectProcessStage == itemProjectProcessStage).FirstOrDefault();
                    projectModelSub.StartDate = Convert.ToDateTime(item.StartDate);
                    projectModelSub.FinishDate = Convert.ToDateTime(item.EndDate);
                    projectModelSub.ResponsibleUserId = item.UserId;
                    _context.ProjectModuleStatus.Update(projectModelSub);
                    _context.SaveChanges();
                }
                else
                {
                    continue;
                }
            }
        }

        public void SaveProjectDetail(PMProjectElementDetails projectElementDetails, decimal netIron, decimal netIronTotal, decimal concrete, decimal concreteTotal)
        {
            var offerCalculate = _context.PmCalculates.Where(x => x.Id ==
            projectElementDetails.PmCalculateId).FirstOrDefault();
            offerCalculate.IronKg = netIron;
            offerCalculate.IronKgTotal = netIronTotal;
            offerCalculate.NetConcrete = concrete;
            offerCalculate.NetConcreteTotal = concreteTotal;
            _context.Update(offerCalculate);
            _context.SaveChanges();
            if (projectElementDetails.Id != 0)
            {
                _context.Update(projectElementDetails);
            }
            else
            {
                _context.PMProjectElementDetails.Add(projectElementDetails);
            }
            try
            {

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void StartProject(int id)
        {
            var proje = _context.ProjectModuleSub.FirstOrDefault(x => x.Id == id);
            if (proje != null && proje.StartProject == false)
            {
                proje.StartProject = true;
                proje.StartProjectTime = DateTime.Now;
                _context.ProjectModuleSub.Update(proje);
                _context.SaveChanges();
            }
        }

        public ProjectModuleStatus StartTask(int id)
        {
            var surec = _context.ProjectModuleStatus.Where(x => x.Id == id).FirstOrDefault();
            if (surec.SubStage == SubStage.None)
            {
                surec.SubStage = SubStage.Start;
            }
            else
            {
                surec.SubStage = SubStage.None;
            }
            _context.ProjectModuleStatus.Update(surec);
            _context.SaveChanges();
            return _context.ProjectModuleStatus.Where(x => x.Id == id).FirstOrDefault();
        }

        public void UpdateHesapDoneleri(string userId, int subId)
        {
            var sub = _context.ProjectModuleSub.Where(x => x.Id == subId).FirstOrDefault();
            var proccess = _context.ProjectModuleStatus.Where(x => x.ProjectProcessStage == ProjectProcessStage.MusteriOnayıAlındı && x.ProjectModuleSubId == subId).FirstOrDefault();
            proccess.StartDate = sub.StartProjectTime;
            proccess.FinishDate = DateTime.Now;
            proccess.ResponsibleUserId = userId;
            proccess.RecipentUserId = userId;
            proccess.SubStage = SubStage.Finish;
            proccess.CompleteDate = DateTime.Now;
            _context.ProjectModuleStatus.Update(proccess);
            _context.SaveChanges();
        }
    }
}
