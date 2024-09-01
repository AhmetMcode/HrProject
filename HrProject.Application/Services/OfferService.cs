using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Presentation.Data.Migrations;
using HrProject.Repository.Base;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Bcpg.Sig;
using RestSharp;
using System.Web.Helpers;

namespace HrProject.Application.Services;

public class OfferService : BaseRepository<Offer>, IOfferService
{
    private readonly IOfferProcessService offerProcessService;
    private readonly INotificationService notificationService;
    private readonly IUserService userService;
    private readonly IProjectModel projectModel;
    private readonly ILastActivityService lastActivityService;

    private readonly ICustomerInteractionOfferService customerInteractionOffer;

    public OfferService(DbContextOptions<ApplicationDbContext> options, IOfferProcessService offerProcessService, INotificationService notificationService, IUserService userService, IProjectModel projectModel, ILastActivityService lastActivityService, ICustomerInteractionOfferService customerInteractionOffer) : base(options)
    {
        this.offerProcessService = offerProcessService;
        this.notificationService = notificationService;
        this.userService = userService;
        this.projectModel = projectModel;
        this.lastActivityService = lastActivityService;

        this.customerInteractionOffer = customerInteractionOffer;
    }

    public IEnumerable<District> GetDistrictsByCityId(int cityId)
    {
        var districts = _context.Districts
      .Where(d => d.CityId == cityId)
      .ToList();

        return districts;
    }

    public List<RopeIron> GetRopeIrons(int offerCalculateId)
    {
        var result = _context.RopeIrons.Include(x => x.OfferCalculate)
                                                  .Include(x => x.ToronDiameter)
                                                  .Where(x => x.OfferCalculateId == offerCalculateId).ToList();
        return result;
    }

    public IEnumerable<Neighbourhood> GetNeighbourhoodByDistrictId(int districtId)
    {
        var neighbourhoods = _context.Neighbourhoods
                                                    .Where(x => x.DistrictId == districtId)
                                                    .ToList();
        return neighbourhoods;
    }

    public OfferCalculate GetOfferCalculate(int calculateId)
    {
        var offerCalculate = _context.OfferCalculates.Where(x => x.Id == calculateId).Include(x => x.OfferPart).ThenInclude(x => x.Offer).Include(x => x.ConcreteClass).FirstOrDefault();
        return offerCalculate;
    }

    public List<OfferCalculate> GetOfferCalculates(int offerId)
    {
        var offerCalculates = _context.OfferCalculates.Where(x => x.OfferPartId == offerId).Include(x => x.ConcreteClass).Include(x => x.ProjectElement).ToList();
        return offerCalculates;
    }
    public List<OfferCalculate> GetOfferCalculatesByOfferId(int offerId)
    {
        var offerParts = _context.OfferParts.Where(x => x.OfferId == offerId).ToList();
        var termins = _context.OfferTerminSub.Where(x => x.OfferId == offerId).FirstOrDefault();
        List<OfferCalculate> cals = new List<OfferCalculate>();
        foreach (var item in offerParts)
        {
            cals.AddRange(_context.OfferCalculates.Where(x => x.OfferPartId == item.Id).Include(x => x.ConcreteClass).Include(x => x.ProjectElementType).ThenInclude(x => x.ProjectElement).ToList());

        }
        cals.GroupBy(x => x.ProjectElementTypeId).ToList();
        return cals;
    }
    public List<OfferCalculate> GetOfferPartCalculates(int offerId)
    {
        var offerCalculates = _context.OfferCalculates.Where(x => x.OfferPartId == offerId).Include(x => x.ConcreteClass).Include(x => x.ProjectElement).Include(x => x.ProjectElementType).ToList();
        return offerCalculates;
    }
    public OfferProjectDocuments GetOfferDocument(int offerId)
    {
        var offer = _context.Offers.Where(x => x.Id == offerId).Include(x => x.OfferProjectDocuments).FirstOrDefault();
        if (offer.OfferProjectDocuments.FirstOrDefault() != null)
        {
            return offer.OfferProjectDocuments.FirstOrDefault();
        }
        else
        {
            OfferProjectDocuments offerProjectDocuments = new OfferProjectDocuments();
            offerProjectDocuments.OfferId = offerId;
            offerProjectDocuments.CreatedTime = DateTime.Now;
            offerProjectDocuments.Document1 = "";
            offerProjectDocuments.Offer = offer;
            return offerProjectDocuments;
        }
    }

    public IEnumerable<Offer> GetOfferInclude()
    {
        IEnumerable<Offer> result = _context.Offers.Include(x => x.City)
                                                   .Include(x => x.ApplicationUser)
                                                   .Include(x => x.District)
                                                   .Include(x => x.OfferProcess)
                                                   .Include(x => x.ResponsibleUser)
                                                   .Include(x => x.OfferProjectDocuments)
                                                   .Include(x => x.CariKart).OrderByDescending(x => x.Id);
        return result;
    }

    public Offer GetOfferIncludeById(int id)
    {
        var result = _context.Offers.Include(x => x.City)
            .Include(x => x.ProjectResponsibleUser).Include(x => x.OfferTechnicalByOffers)
                                                   .Include(x => x.ApplicationUser)
                                                   .Include(x => x.District)
                                                   .Include(x => x.Neighbourhood)
                                                   .Include(x => x.OfferProcess)
                                                   .Include(x => x.OfferParts).ThenInclude(x => x.OfferCalculates).ThenInclude(x => x.ProjectElement)
                                                   .Include(x => x.CariKart).Where(x => x.Id == id).FirstOrDefault();
        result.ResponsibleUser = _context.ApplicationUsers.Where(x => x.Id == result.ResponsibleUserId).FirstOrDefault();
        return result;
    }


    public List<ProjectElementDetails> GetProjectDetail(int projectElementId)
    {

        var result = _context.ProjectElementDetails.Include(x => x.OfferCalculate)
                                                   .Include(x => x.IronDiameterWeight)
                                                   .Where(x => x.OfferCalculateId == projectElementId).ToList();
        return result;
    }

    public List<WickerIronCalculate> GetWickerIronCalculate(int offerCalculateId)
    {
        var result = _context.WickerIronCalculate.Include(x => x.OfferCalculate)
                                                    .Include(x => x.SteelMeshType)
                                                    .Where(x => x.OfferCalculateId == offerCalculateId).ToList();
        return result;
    }

    public async Task<Offer> OfferAssignment(int offerId, string assignmentUserId, string assignerUserId, string projectUserId, DateTime hesapBitisi, DateTime projeBitisi, DateTime terminTarihi, string projeAtamaAciklama, string hesapAtamaAciklama)
    {

        var offer = _context.Offers.Where(x => x.Id == offerId).FirstOrDefault();
        var offerProccessOld = _context.OfferProcess.Where(x => x.OfferId == offerId && x.OfferProcessStage == Domain.Enums.OfferProcessStage.Eklendi).FirstOrDefault();
        var responsibleUser = await userService.GetById(assignmentUserId);
        var projectUser = await userService.GetById(projectUserId);
        var assignerUser = await userService.GetById(assignerUserId);
        offer.UpdateTime = DateTime.Now;
        offer.ProjectResponsibleUserId = projectUserId;
        offer.ResponsibleUserId = assignmentUserId;
        offer.LengthOfTermCalculate = hesapBitisi;
        offer.LengthOfTermProject = projeBitisi;
        offer.DescResponseCalculate = hesapAtamaAciklama;
        offer.DescResponseProject = projeAtamaAciklama;
        offer.LengthOfTerm = terminTarihi;
        _context.Offers.Update(offer);
        LastActivity lastActivity = new LastActivity();
        if (responsibleUser == null)
        {
            lastActivity.Url = "Offer/Detail/" + offer.Id;
            lastActivity.Renk = "success";
            lastActivity.CreatedTime = DateTime.Now;
            lastActivity.Icerik = assignerUser.Name + " " + assignerUser.SurName + "tarafından " + offer.Name + "  teklifinin atamaları yapılmıştır." + projectUser.Name + " " + projectUser.SurName + " proje çizimi için." + responsibleUser.Name + " " + responsibleUser.SurName + " hesap için";
            lastActivityService.Insert(lastActivity);
            OfferProcess newOfferProcess = new OfferProcess();
            newOfferProcess.OfferId = offerId;
            newOfferProcess.OfferProcessStage = Domain.Enums.OfferProcessStage.AtamaYapildi;
            newOfferProcess.StarterUserId = assignerUserId;
            newOfferProcess.CreatedTime = DateTime.Now;
            newOfferProcess.IsActive = true;
            newOfferProcess.ResponsibleUserId = assignmentUserId;
            newOfferProcess.StartTime = DateTime.Now;
            _context.LastActivitys.Add(lastActivity);
            _context.OfferProcess.Add(newOfferProcess);
            _context.SaveChanges();
        }
        else
        {
            lastActivity.Url = "Offer/Detail/" + offer.Id;
            lastActivity.Renk = "danger";
            lastActivity.CreatedTime = DateTime.Now;
            lastActivity.Icerik = assignerUser.Name + " " + assignerUser.SurName + "tarafından " + offer.Name + "  teklifinin atamaları guncellenmiştir." + projectUser.Name + " " + projectUser.SurName + " proje çizimi için." + responsibleUser.Name + " " + responsibleUser.SurName + " hesap için";
            OfferProcess newOfferProcess = new OfferProcess();
            newOfferProcess.OfferId = offerId;
            newOfferProcess.OfferProcessStage = Domain.Enums.OfferProcessStage.AtamaYapildi;
            newOfferProcess.StarterUserId = assignerUserId;
            newOfferProcess.CreatedTime = DateTime.Now;
            newOfferProcess.IsActive = true;
            newOfferProcess.ResponsibleUserId = assignmentUserId;
            newOfferProcess.StartTime = DateTime.Now;
            _context.OfferProcess.Add(newOfferProcess);
            offerProccessOld.EndTime = DateTime.Now;
            offerProccessOld.IsActive = false;
            _context.LastActivitys.Add(lastActivity);
            _context.OfferProcess.Update(offerProccessOld);
            _context.SaveChanges();

        }
        return offer;
    }

    public void SaveRopeIrons(List<RopeIron> hasirIrons, decimal ropIron, decimal ropIronTotal)
    {

        var offerCalculate = _context.OfferCalculates.Where(x => x.Id ==
        hasirIrons.FirstOrDefault().OfferCalculateId).FirstOrDefault();
        offerCalculate.RopeIronKg = ropIron;
        offerCalculate.RopeIronKgTotal = ropIronTotal;
        _context.Update(offerCalculate);
        _context.SaveChanges();
        foreach (var item in hasirIrons)
        {
            if (item.Id != 0)
            {
                _context.Update(item);
            }
            else
            {
                _context.RopeIrons.Add(item);
            }
            try
            {

                _context.SaveChanges();
            }
            catch (Exception)
            {

                continue;
            }

        }
    }

    public void SaveOfferCalculates(List<OfferCalculate> offerCalculates)
    {

        foreach (var item in offerCalculates)
        {
            try
            {
                if (item.Id != 0)
                {
                    var calcualte = _context.OfferCalculates.Where(x => x.Id == item.Id).FirstOrDefault();
                    calcualte.GrossConcrete = item.GrossConcrete;
                    calcualte.Price = item.Price;
                    calcualte.Length = item.Length;
                    calcualte.GrossConcreteTotal = item.GrossConcreteTotal * item.Price;
                    _context.OfferCalculates.Update(calcualte);
                    _context.SaveChanges();
                }
                else
                {
                    if (item.GrossConcrete == 0 || item.GrossConcrete == null)
                    {
                        continue;
                    }
                    var code = _context.OfferCalculates.Where(x => x.OfferPartId == offerCalculates.FirstOrDefault().OfferPartId && x.ProjectElementId
                    == item.ProjectElementId).ToList().Count;
                    item.ElementCode = _context.ProjectElements.Where(x => x.Id == item.ProjectElementId).FirstOrDefault().Code + (code + 1);
                    _context.OfferCalculates.Add(item);
                    _context.SaveChanges();

                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }

    public void SaveProjectDetail(ProjectElementDetails projectElementDetails, decimal netIron, decimal netIronTotal, decimal concrete, decimal concreteTotal)
    {
        var offerCalculate = _context.OfferCalculates.Where(x => x.Id ==
        projectElementDetails.OfferCalculateId).FirstOrDefault();
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
            _context.ProjectElementDetails.Add(projectElementDetails);
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

    public void SaveWickerIronJson(List<WickerIronCalculate> wickerIronCalculate, decimal wi, decimal wiTotal)
    {
        var offerCalculate = _context.OfferCalculates.Where(x => x.Id ==
        wickerIronCalculate.FirstOrDefault().OfferCalculateId).FirstOrDefault();
        offerCalculate.WickerIronKg = wi;
        offerCalculate.WickerIronKgTotal = wiTotal;
        _context.Update(offerCalculate);
        _context.SaveChanges();

        foreach (var item in wickerIronCalculate)
        {
            if (item.Id != 0)
            {
                _context.Update(item);
            }
            else
            {
                _context.WickerIronCalculate.Add(item);
            }
            try
            {

                _context.SaveChanges();
            }
            catch (Exception)
            {

                continue;
            }

        }

    }

    public void UpdateProjectDocuments(OfferProjectDocuments model)
    {
        Offer offer = _context.Offers.Where(x => x.Id == model.OfferId).FirstOrDefault();
        model.UpdateTime = DateTime.Now;
        OfferProcess offerProcess = _context.OfferProcess.Where(x => x.OfferId == model.OfferId).OrderByDescending(x => x.Id).FirstOrDefault();
        offerProcess.IsActive = false;
        offerProcess.EndTime = DateTime.Now;
        _context.OfferProcess.Update(offerProcess);
        OfferProcess newOfferProcess = new OfferProcess();
        newOfferProcess.OfferId = model.OfferId;
        newOfferProcess.StartTime = DateTime.Now;
        newOfferProcess.ResponsibleUserId = offer.ResponsibleUserId;
        newOfferProcess.IsActive = true;
        newOfferProcess.OfferProcessStage = Domain.Enums.OfferProcessStage.CizimYapildi;
        _context.OfferProcess.Add(newOfferProcess);
        _context.OfferProjectDocuments.Update(model);
        _context.SaveChanges();
    }

    public void SaveAnkrajIrons(List<AnkrajIron> ankrajIrons, decimal ankraj, decimal ankrajTotal)
    {
        var offerCalculate = _context.OfferCalculates.Where(x => x.Id ==
       ankrajIrons.FirstOrDefault().OfferCalculateId).FirstOrDefault();
        offerCalculate.ANKRAJ = ankraj;
        offerCalculate.ANKRAJTotal = ankrajTotal;
        _context.Update(offerCalculate);
        _context.SaveChanges();
        foreach (var item in ankrajIrons)
        {
            if (item.Id != 0)
            {
                _context.Update(item);
            }
            else
            {
                _context.AnkrajIrons.Add(item);
            }
            try
            {

                _context.SaveChanges();
            }
            catch (Exception)
            {

                continue;
            }

        }
    }

    public List<AnkrajIron> GetAnkrajIrons(int offerCalculateId)
    {
        var result = _context.AnkrajIrons.Include(x => x.OfferCalculate)
                                                  .Where(x => x.OfferCalculateId == offerCalculateId).ToList();
        return result;
    }

    public void FinishCalculate(int offerId, string userId)
    {
        var offer = _context.Offers.Where(x => x.Id == offerId).FirstOrDefault();
        var offerProccess = _context.OfferProcess.Where(x => x.OfferId == offerId).OrderByDescending(x => x.Id).FirstOrDefault();
        offerProccess.IsActive = false;
        offerProccess.EndTime = DateTime.Now;
        _context.OfferProcess.Update(offerProccess);
        OfferProcess newOfferProcess = new OfferProcess();
        newOfferProcess.StartTime = DateTime.Now;
        newOfferProcess.OfferProcessStage = Domain.Enums.OfferProcessStage.HesapYapiliyor;
        newOfferProcess.StarterUserId = userId;
        newOfferProcess.IsActive = true;
        newOfferProcess.OfferId = offerId;
        _context.OfferProcess.Add(newOfferProcess);
        _context.SaveChanges();
    }

    public List<OfferProcess> GetOfferProcess(int offerId)
    {
        return _context.OfferProcess.Where(x => x.OfferId == offerId).Include(x => x.ResponsibleUser).Include(x => x.StarterUser).ToList();
    }

    public List<Domain.Entities.ConcreteClass> GetConcretsClass()
    {
        return _context.ConcreteClass.ToList();
    }

    public void DeleteCalculate(int id)
    {

        _context.OfferCalculates.Remove(_context.OfferCalculates.Where(x => x.Id == id).FirstOrDefault());
        _context.SaveChanges();
    }

    public List<KeyValuePair<string, decimal>> GetConcretsWithVaVlue(int offerId)
    {
        List<OfferCalculate> offerCalculates = _context.OfferCalculates
            .Where(x => x.OfferPartId == offerId)
            .Include(x => x.ConcreteClass)
            .ToList();

        var groupedByConcreteClass = offerCalculates
            .GroupBy(x => x.ConcreteClass.Id) // Group by ConcreteClass.Id
            .Select(group => new
            {
                ConcreteClass = group.First().ConcreteClass, // Take the ConcreteClass from the first item in the group
                TotalGrossConcrete = group.Sum(x => x.GrossConcrete * x.Price ?? 0) // Calculate sum of GrossConcrete within each group
            })
            .ToList();

        var result = groupedByConcreteClass.Select(x => new KeyValuePair<string, decimal>(
            x.ConcreteClass?.Name ?? "Unknown", // Provide a default value if Name is null
            x.TotalGrossConcrete
        ))
        .ToList();

        return result;
    }

    public decimal GetTotalIronValue(int offerId)
    {
        List<OfferCalculate> offerCalculates = _context.OfferCalculates
         .Where(x => x.OfferPartId == offerId)
         .ToList();

        // Toplam demiri hesaplar.
        var totalIron = Convert.ToDecimal(offerCalculates.Sum(x => x.IronKg * x.Price));

        // Toplam demiri döndürür.
        return totalIron;
    }

    public decimal GetTotalWickerValue(int offerId)
    {
        List<OfferCalculate> offerCalculates = _context.OfferCalculates
          .Where(x => x.OfferPartId == offerId)
          .ToList();

        // Toplam demiri hesaplar.
        var totalIron = Convert.ToDecimal(offerCalculates.Sum(x => x.WickerIronKg * x.Price));

        // Toplam demiri döndürür.
        return totalIron;
    }

    public List<KeyValuePair<string, decimal>> GetRopeIronsTotalValue(int offerId)
    {
        List<RopeIron> ropeIrons = _context.RopeIrons.Include(x => x.ToronDiameter)
             .Include(x => x.OfferCalculate).ThenInclude(x => x.OfferPart).Where(x => x.OfferCalculate.OfferPartId == offerId)
             .ToList();

        var groupedByConcreteClass = ropeIrons
            .GroupBy(x => x.ToronDiameter.Id) // Group by ConcreteClass.Id
            .Select(group => new
            {
                Toron = group.First().ToronDiameter, // Take the ConcreteClass from the first item in the group
                TotalGrossConcrete = group.Sum(x => x.Weight * x.OfferCalculate.Price) // Calculate sum of GrossConcrete within each group
            })
            .ToList();

        var result = groupedByConcreteClass.Select(x => new KeyValuePair<string, decimal>(
            x.Toron.Code ?? "Unknown", // Provide a default value if Name is null
            x.TotalGrossConcrete
        ))
        .ToList();

        return result;
    }

    public List<ToronDiameter> GetTorons()
    {
        return _context.ToronDiameters.ToList();
    }

    public List<OfferPart> GetAndAddOfferParts(int offerId)
    {
        var offerParts = _context.OfferParts.Where(x => x.OfferId == offerId).Include(x => x.OfferCalculates).ToList();
        var offer = _context.Offers.Where(x => x.Id == offerId).FirstOrDefault();
        // OfferParts'tan belirli bir teklifin parçalarını seç




        // Sonucu kullanarak bir şeyler yapabilirsiniz, örneğin:
        if (offerParts.Count != 5)
        {
            if (offerParts != null)
            {
                _context.OfferParts.RemoveRange(offerParts);
                _context.SaveChanges();
            }
            for (int i = 0; i < 5; i++)
            {
                OfferPart offerPart = new OfferPart();
                offerPart.PartName = "";
                offerPart.OfferId = offerId;
                _context.OfferParts.Add(offerPart);

            }
            _context.SaveChanges();
            return _context.OfferParts.Where(x => x.OfferId == offerId).Include(x => x.OfferCalculates).ToList();
        }
        else
        {
            var selectedParts = offerParts;

            // Her parçanın metre karesini maliyetine bölen ve sonucu toplayan bir işlem gerçekleştir
            decimal metrekare = 0;
            decimal vkadet = 0;
            decimal CpMetreKare = 0;
            decimal metreKup = 0;
            foreach (var item in offerParts)
            {
                var beton = BetonlariTopla(item.Id);
                item.Demir = DemirTopla(item.Id);
                item.Halat = HalatTopla(item.Id);
                item.Hasir = HasirTopla(item.Id);
                item.Beton = beton;
                if (beton != 0)
                {
                    metreKup += item.TotalFee / beton;
                }
                if (item.Miktar != 0)
                {
                    metrekare += item.TotalFee / item.Miktar;

                }
                if (item.VkAdet != 0)
                {
                    vkadet += item.TotalFee / item.VkAdet;
                }
                if (item.CpMetreKare != 0)
                {
                    CpMetreKare += item.TotalFee / item.CpMetreKare;
                }
                _context.OfferParts.Update(item);

            }
            offer.MektreKareSatis = metrekare;
            offer.VkAdetSatis = vkadet;
            offer.CpSatis = CpMetreKare;
            offer.MetrekupSatis = metreKup;
            _context.Offers.Update(offer);
            _context.SaveChanges();
        }
        return offerParts;
    }

    public async Task UpdateTotalParts(List<OfferPart> offerParts, decimal ExchangeRate, decimal Overheads, decimal Inflation, Offer offers)
    {

        var offer = _context.Offers.FirstOrDefault(x => x.Id == offerParts.FirstOrDefault().OfferId);
        if (offer != null)
        {
            offer.ExchangeRate = ExchangeRate;
            offer.Overheads = Overheads;
            offer.Inflation = Inflation;

            foreach (var ofitem in offerParts)
            {
                try
                {
                    var offerMaterials = _context.OfferCostCalculateDetails.Where(x => x.OfferPartId == ofitem.Id).ToList();
                    decimal totalTutar = 0M;
                    foreach (var item in offerMaterials)
                    {
                        totalTutar += item.Amount;
                    }

                    var offerpart = _context.OfferParts.FirstOrDefault(x => x.Id == ofitem.Id);
                    if (offerpart != null)
                    {
                        decimal cost = totalTutar;
                        decimal exc = cost * (ExchangeRate / 100M);
                        decimal ovd = cost * (Overheads / 100M);
                        decimal inf = cost * (Inflation / 100M);
                        offerpart.PartName = ofitem.PartName;

                        offerpart.Offer = offer;
                        offerpart.Cost = (cost + exc + ovd + inf);
                        decimal profit = (offerpart.Cost * (ofitem.ProfitRate / 100M));
                        offerpart.ProfitTotal = profit;
                        offerpart.ProfitRate = ofitem.ProfitRate;
                        offerpart.TotalFee = offerpart.Cost + offerpart.ProfitTotal;
                        offerpart.DescByPrint = _context.OfferParts.FirstOrDefault(x => x.Id == offerpart.Id)?.DescByPrint;
                        offerpart.Offer.Km = offers.Km;
                        offerpart.Offer.MesafeKatsayisi = offers.MesafeKatsayisi;
                        offerpart.Offer.EgimKatsayi = offers.EgimKatsayi;
                        // offerpart güncelleme işlemi
                        _context.OfferParts.Update(offerpart);
                    }
                }
                catch (Exception)
                {
                    // Hata durumunda devam et
                    continue;
                }
            }
            // Tüm güncelleme işlemlerini kaydet
            _context.SaveChanges();
        }



    }

    public async void UpdateInflation(int OfferId, decimal ExchangeRate, decimal Overheads, decimal Inflation)
    {
        var offer = _context.Offers.FirstOrDefault(x => x.Id == OfferId);
        offer.ExchangeRate = ExchangeRate;
        offer.Overheads = Overheads;
        offer.Inflation = Inflation;

        try
        {

            _context.Entry(offer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public decimal GetTotalConcreteValue(int offerPartId)
    {
        var ofcs = _context.OfferCalculates
             .Where(x => x.OfferPartId == offerPartId)
             .ToList();
        decimal total = (decimal)_context.OfferCalculates
             .Where(x => x.OfferPartId == offerPartId)
             .ToList().Sum(x => x.GrossConcrete * x.Price);
        return total;
    }
    public decimal BetonlariTopla(int offerPartId)
    {
        var acs = _context.OfferCostCalculateDetails
                       .Where(x => x.OfferPartId == offerPartId &&
                                   x.OfferMaterials.CurrentValue.CurrentValueName.ToUpper().Contains("BETON"))
                       .Sum(x => x.Quantity);

        return acs;
    }
    public decimal DemirTopla(int offerPartId)
    {
        var acs = _context.OfferCostCalculateDetails
                       .Where(x => x.OfferPartId == offerPartId &&
                                   x.OfferMaterials.CurrentValue.CurrentValueName.ToLower().Contains("demir"))
                       .Sum(x => x.Quantity);

        return acs;
    }
    public decimal HasirTopla(int offerPartId)
    {
        var acs = _context.OfferCostCalculateDetails
                       .Where(x => x.OfferPartId == offerPartId &&
                                   x.OfferMaterials.CurrentValue.CurrentValueName.ToLower().Contains("hasır"))
                       .Sum(x => x.Quantity);

        return acs;
    }
    public decimal HalatTopla(int offerPartId)
    {
        var acs = _context.OfferCostCalculateDetails
                       .Where(x => x.OfferPartId == offerPartId &&
                                   x.OfferMaterials.CurrentValue.CurrentValueName.ToLower().Contains("halat"))
                       .Sum(x => x.Quantity);

        return acs;
    }
    public void ReloadCost(int offerPartId)
    {
        var offerMaterials = _context.OfferCostCalculateDetails.Where(x => x.OfferPartId == offerPartId).ToList();
        decimal totalTutar = 0M;
        foreach (var item in offerMaterials)
        {
            totalTutar += item.Amount;
        }
        var offerpart = _context.OfferParts.Where(x => x.Id == offerPartId).Include(x => x.Offer).FirstOrDefault();
        decimal profit = totalTutar * offerpart.ProfitRate;
        offerpart.ProfitTotal = (totalTutar * offerpart.ProfitRate) / 100M;
        offerpart.TotalFee = offerpart.Cost + offerpart.ProfitTotal;
        decimal cost = totalTutar;
        decimal ExchangeRate = offerpart.Offer.ExchangeRate;
        decimal Overheads = offerpart.Offer.Overheads;
        decimal Inflation = offerpart.Offer.Inflation;
        decimal exc = cost * (ExchangeRate / 100M);
        decimal ovd = cost * (Overheads / 100M);
        decimal inf = cost * (Inflation / 100M);

        offerpart.Cost = (cost + exc + ovd + inf);
        offerpart.ProfitTotal = (offerpart.Cost * (offerpart.ProfitRate / 100M));
        offerpart.TotalFee = offerpart.Cost + offerpart.ProfitTotal;
        offerpart.DescByPrint = _context.OfferParts.Where(x => x.Id == offerpart.Id).FirstOrDefault().DescByPrint;
        _context.OfferParts.Update(offerpart);
        _context.SaveChanges();
    }

    public List<OfferCalculate> GetOfferCalculateSimilar(int offerCalculateId)
    {
        var sss = _context.OfferCalculates.Where(x => x.Id == offerCalculateId).FirstOrDefault();
        var lowerBound = sss.Length - 10;
        var upperBound = sss.Length + 10;

        var similars = _context.OfferCalculates
            .Where(x => x.Length >= lowerBound && x.Length <= upperBound && x.ProjectElementTypeId == sss.ProjectElementTypeId && x.Id != sss.Id && x.ConcreteClassId == sss.ConcreteClassId).Include(x => x.ConcreteClass).Include(x => x.ProjectElement)
            .ToList();

        return similars;
    }

    public void TransferCalculate(int transferId, int calculateId)
    {
        var transfer = _context.OfferCalculates.Where(x => x.Id == transferId).FirstOrDefault();
        var calculate = _context.OfferCalculates.Where(x => x.Id == calculateId).FirstOrDefault();
        var transferProjectElements = _context.ProjectElementDetails.Where(x => x.OfferCalculateId == transferId).ToList();
        var transferWickerIrons = _context.WickerIronCalculate.Where(x => x.OfferCalculateId == transferId).ToList();
        var transferRopeIron = _context.RopeIrons.Where(x => x.OfferCalculateId == transferId).ToList();
        var transferAnkraj = _context.AnkrajIrons.Where(x => x.OfferCalculateId == transferId).ToList();
        List<AnkrajIron> newListAnkraj = new List<AnkrajIron>();
        List<ProjectElementDetails> newListProjectElementDetails = new List<ProjectElementDetails>();
        List<WickerIronCalculate> newListWickerIronCalculate = new List<WickerIronCalculate>();
        List<RopeIron> newListRopeIron = new List<RopeIron>();
        decimal toplam = 0M;
        foreach (var item in transferAnkraj)
        {
            AnkrajIron ankrajIron = new AnkrajIron();
            ankrajIron.Thick = item.Thick;
            ankrajIron.Width = item.Width;
            ankrajIron.Weight = item.Weight;
            ankrajIron.CreatedTime = DateTime.Now;
            ankrajIron.Price = item.Price;
            ankrajIron.Length = item.Length;
            ankrajIron.OfferCalculateId = calculateId;
            newListAnkraj.Add(ankrajIron);
        }
        foreach (var item in transferProjectElements)
        {
            ProjectElementDetails projectElementDetails = new ProjectElementDetails();
            projectElementDetails.IronDiameterWeightId = item.IronDiameterWeightId;
            projectElementDetails.TotalWeight = item.TotalWeight;
            projectElementDetails.Size = item.Size;
            projectElementDetails.Similar = item.Similar;
            projectElementDetails.Price = item.Price;
            projectElementDetails.PozNumber = item.PozNumber;
            projectElementDetails.OfferCalculateId = calculateId;
            toplam += item.TotalWeight;
            newListProjectElementDetails.Add(projectElementDetails);

        }
        foreach (var item in transferWickerIrons)
        {
            WickerIronCalculate wicker = new WickerIronCalculate();
            wicker.Width = item.Width;
            wicker.Weight = item.Weight;
            wicker.SteelMeshTypeId = item.SteelMeshTypeId;
            wicker.Similar = item.Similar;
            wicker.OfferCalculateId = item.OfferCalculateId;
            wicker.Length = item.Length;
            newListWickerIronCalculate.Add(wicker);

        }
        foreach (var item in transferRopeIron)
        {
            RopeIron ropeIron = new RopeIron();
            ropeIron.Weight = item.Weight;
            ropeIron.ToronDiameterId = item.ToronDiameterId;
            ropeIron.Length = item.Length;
            ropeIron.Price = item.Price;
            ropeIron.OfferCalculateId = calculateId;
            newListRopeIron.Add(ropeIron);

        }
        calculate.ANKRAJ = newListAnkraj.Sum(x => x.Weight);
        calculate.ANKRAJTotal = calculate.ANKRAJ * calculate.Price;
        calculate.GrossConcreteTotal = calculate.GrossConcrete * calculate.Price;
        calculate.IronKg = toplam;
        calculate.IronKgTotal = toplam * calculate.Price;
        calculate.RopeIronKg = newListRopeIron.Sum(x => x.Weight);
        calculate.RopeIronKgTotal = newListRopeIron.Sum(x => x.Weight) * calculate.Price;
        calculate.WickerIronKg = newListWickerIronCalculate.Sum(x => x.Weight);
        calculate.WickerIronKgTotal = newListWickerIronCalculate.Sum(x => x.Weight) * calculate.Price;
        calculate.NetConcrete = calculate.GrossConcrete - (toplam / 7800M);
        calculate.NetConcreteTotal = calculate.NetConcrete * calculate.Price;
        _context.AnkrajIrons.AddRange(newListAnkraj);
        _context.ProjectElementDetails.AddRange(newListProjectElementDetails);
        _context.WickerIronCalculate.AddRange(newListWickerIronCalculate);
        _context.RopeIrons.AddRange(newListRopeIron);
        _context.SaveChanges();
        _context.OfferCalculates.Update(calculate);
        _context.SaveChanges();


    }

    public Offer GetOfferByPartId(int partId)
    {
        var offerpart = _context.OfferParts.Where(x => x.Id == partId).Include(x => x.Offer).FirstOrDefault();
        return offerpart.Offer;
    }

    public void SendCalculates(int offerId)
    {
        var activeProcess = offerProcessService
       .Where(x => x.OfferId == offerId && x.IsActive == true && x.OfferProcessStage == Domain.Enums.OfferProcessStage.YoneticiOnayinaGonderildi)
       .FirstOrDefault();
        var lastOffer = offerProcessService.Where(x => x.OfferId == offerId && x.IsActive == true).FirstOrDefault();
        if (lastOffer != null && lastOffer.OfferProcessStage == Domain.Enums.OfferProcessStage.HesapYapiliyor)
        {
            lastOffer.IsActive = false;
            lastOffer.UpdateTime = DateTime.UtcNow;
            lastOffer.EndTime = DateTime.UtcNow;
            _context.OfferProcess.Update(lastOffer);
            _context.SaveChanges();
        }
        if (activeProcess == null)
        {
            OfferProcess offerProcess = new OfferProcess();
            offerProcess.OfferId = offerId;
            offerProcess.IsActive = true;
            offerProcess.StartTime = DateTime.UtcNow;
            offerProcess.StarterUserId = lastOffer?.ResponsibleUserId;
            offerProcess.OfferProcessStage = Domain.Enums.OfferProcessStage.YoneticiOnayinaGonderildi;
            _context.Add(offerProcess);
            _context.SaveChanges();
        }

    }

    public async Task SendProjectModule(int offerId, string userId)
    {


        var lastOffer = offerProcessService.Where(x => x.OfferId == offerId && x.IsActive == true).FirstOrDefault();
        var offer = GetById(offerId);

        if (lastOffer != null)
        {
            lastOffer.IsActive = false;
            lastOffer.UpdateTime = DateTime.UtcNow;
            lastOffer.EndTime = DateTime.UtcNow;
            _context.OfferProcess.Update(lastOffer);
            _context.SaveChanges();
        }
        ProjectModuleSub projectModuleSub = _context.ProjectModuleSub.Where(x => x.OfferId == offerId).FirstOrDefault();
        if (projectModuleSub == null)
        {
            projectModuleSub.OfferId = projectModuleSub.OfferId;
            projectModuleSub.Name = offer.Name;
            _context.ProjectModuleSub.Add(projectModuleSub);
            _context.SaveChanges();
        }
        OfferProcess offerProcess = new OfferProcess();
        offerProcess.OfferId = offerId;
        offerProcess.IsActive = true;
        offerProcess.StartTime = DateTime.UtcNow;
        offerProcess.StarterUserId = lastOffer?.ResponsibleUserId;
        offerProcess.OfferProcessStage = Domain.Enums.OfferProcessStage.Sozlesme;
        _context.SaveChanges();


        offer.SendProject = true;
        _context.Offers.Update(offer);
        _context.SaveChanges();
    }
    public void UpdateDescParts(List<OfferPart> offerParts)
    {
        foreach (var item in offerParts)
        {
            OfferPart offerPart = _context.OfferParts.Where(x => x.Id == item.Id).FirstOrDefault();
            offerPart.DescByPrint = item.DescByPrint;
            offerPart.Miktar = item.Miktar;
            _context.OfferParts.Update(offerPart);

        }
        _context.SaveChanges();
    }

    public List<OfferTechnicalByOffer> GetAndAddOfferTech(int offerId)
    {
        List<OfferTechnicalByOffer> offerTechnicalByOffers = new List<OfferTechnicalByOffer>();
        var offerTechs = _context.OfferTechnicals.ToList();
        foreach (var item in offerTechs)
        {
            var elemet = _context.OfferTechnicalByOffers.Where(x => x.OfferTechnicalId == item.Id && x.OfferId == offerId).FirstOrDefault();
            if (elemet != null)
            {

            }
            else
            {
                OfferTechnicalByOffer offerTechnicalByOffer = new OfferTechnicalByOffer();
                offerTechnicalByOffer.OfferId = offerId;
                offerTechnicalByOffer.Name = item.Name;
                offerTechnicalByOffer.IsActive = true;
                offerTechnicalByOffer.Order = item.Order;
                offerTechnicalByOffer.OfferTechnicalId = item.Id;
                offerTechnicalByOffer.Value = "";
                _context.OfferTechnicalByOffers.Add(offerTechnicalByOffer);
                _context.SaveChanges();
            }
        }
        return _context.OfferTechnicalByOffers.Where(x => x.OfferId == offerId).Include(x => x.OfferTechnical).ToList();
    }

    public async Task UpdateOfferTechs(List<OfferTechnicalByOffer> offers)
    {
        foreach (var item in offers)
        {

            var elemet = _context.OfferTechnicalByOffers.Where(x => x.Id == item.Id).FirstOrDefault();
            if (elemet != null)
            {
                elemet.Order = item.Order;
                elemet.Name = item.Name;
                elemet.IsActive = item.IsActive;
                elemet.Value = item.Value;
                _context.OfferTechnicalByOffers.Update(elemet);
                _context.SaveChanges();
            }

        }
    }

    public string GenerateCode()
    {
        string code = DateTime.Now.Year.ToString().Substring(2, 2); ;
        code += "-";
        code += (_context.Offers.ToList().Count() + 1).ToString("000");
        code += "/";
        code += "0";
        return code;
    }

    public int ConfirmCalculates(int id)
    {
        var offerCalculate = _context.OfferCalculates
    .Include(x => x.OfferPart)
    .ThenInclude(x => x.Offer)
    .Where(x => x.Id == id)
    .FirstOrDefault();

        var offerparts = _context.OfferParts
            .Where(x => x.OfferId == offerCalculate.OfferPart.OfferId).Include(x => x.OfferCalculates)
            .ToList();

        offerCalculate.ConfirmBy = true;
        _context.Entry(offerCalculate).State = EntityState.Modified;
        _context.SaveChanges();

        if (offerparts.All(op => op.OfferCalculates.All(oc => oc.ConfirmBy)))
        {
            var offer = _context.Offers.Where(x => x.Id == offerparts.FirstOrDefault().OfferId).FirstOrDefault();
            offer.OfferCalculateConfirm = true;
            offer.Kilit = true;
            _context.Offers.Update(offer);
            _context.SaveChanges();
            var offerProccess = _context.OfferProcess.Where(x => x.OfferId == offer.Id && x.IsActive == true).FirstOrDefault();
            offerProccess.IsActive = false;
            offerProccess.EndTime = DateTime.Now;
            _context.Entry(offerProccess).State = EntityState.Modified;
            OfferProcess offerProcess2 = new OfferProcess();
            offerProcess2.OfferId = offer.Id;
            offerProcess2.OfferProcessStage = Domain.Enums.OfferProcessStage.MusteriBekleniyor;
            offerProcess2.StartTime = DateTime.Now;
            offerProcess2.IsActive = true;
            _context.OfferProcess.Add(offerProcess2);

            _context.SaveChanges();
        }
        return offerCalculate.OfferPartId;
    }

    public async Task<List<KeyValuePair<string, string>>> GetReport()
    {
        var offers = _context.Offers.ToList();
        var offerUsers = await userService.GetOfferUsers();
        offerUsers = offerUsers.ToList();
        var reportList = new List<KeyValuePair<string, string>>();

        foreach (var item in offerUsers)
        {
            var offerKey = _context.Offers.Count(x => x.ResponsibleUserId == item.Id);
            var responsibleUserKey = item.Email;

            reportList.Add(new KeyValuePair<string, string>(offerKey.ToString(), responsibleUserKey));
        }
        return reportList;
    }




    public OfferTerminSub GetAndAddOfferTerminSub(int offerId)
    {
        var offerParts = GetAndAddOfferParts(offerId);
        var projectElements = new List<OfferCalculate>();
        //foreach (var item in offerParts)
        //{
        //    var ps = GetOfferPartCalculates(item.Id);
        //    projectElements.AddRange(ps);

        //}
        var projectElements2 = GetOfferCalculates(offerId);
        var offerTerminSub = _context.OfferTerminSub.Where(x => x.OfferId == offerId).Include(x => x.OfferTerminDetails).ThenInclude(x => x.ProjectElementType).ThenInclude(x => x.ProjectElement).FirstOrDefault();
        if (offerTerminSub != null)
        {
            return offerTerminSub;
        }
        else
        {
            OfferTerminSub offerTerminSub1 = new OfferTerminSub();
            offerTerminSub1.OfferId = offerId;
            offerTerminSub1.TerminType = TerminType.Dusuk;
            offerTerminSub1.OfferTerminDetails = new List<OfferTerminDetail>();
            foreach (var item in projectElements)
            {
                OfferTerminDetail offerTerminDetail = new OfferTerminDetail();
                offerTerminDetail.QuanTity = item.Price;
                offerTerminDetail.Length = item.Length;
                offerTerminDetail.CalculatePozNumber = item.ElementCode;
                offerTerminDetail.OfferTerminSubId = offerTerminSub1.Id;
                offerTerminDetail.ProjectElementTypeId = (int)item.ProjectElementTypeId;
                offerTerminSub1.OfferTerminDetails.Add(offerTerminDetail);
            }
            _context.OfferTerminSub.Add(offerTerminSub1);
            _context.SaveChanges();
            return _context.OfferTerminSub.Where(x => x.OfferId == offerId).Include(x => x.OfferTerminDetails).ThenInclude(x => x.ProjectElementType).ThenInclude(x => x.ProjectElement).FirstOrDefault();
        }
    }
    public OfferTerminSub GetOfferTerminSub(int offerId)
    {

        return _context.OfferTerminSub.Where(x => x.OfferId == offerId).Include(x => x.OfferTerminDetails).ThenInclude(x => x.ProjectElementType).ThenInclude(x => x.ProjectElement).FirstOrDefault();
    }

    public OfferTerminSub UpdatePlanlamaTermin(OfferTerminSub offerTerminSub)
    {
        offerTerminSub.send = true;
        _context.OfferTerminSub.Update(offerTerminSub);
        _context.SaveChanges();
        return offerTerminSub;
    }

    public List<OfferTerminSub> GetAllOfferTerminSubBySend()
    {
        return _context.OfferTerminSub.Include(x => x.Offer).ToList().OrderByDescending(x => x.Id).ToList();
    }

    public List<RopeIron> GetRopeByPartIdIrons(int offerPartId)
    {
        var result = _context.RopeIrons.Include(x => x.OfferCalculate).ThenInclude(x => x.OfferPart)
        .Include(x => x.ToronDiameter).Where(x => x.OfferCalculate.OfferPartId == offerPartId).ToList();
        return result;
    }

    public void DeleteProjectDetail(int id)
    {
        var offerCalculate = _context.ProjectElementDetails.Where(x => x.Id == id).FirstOrDefault();
        _context.Remove(offerCalculate);
        _context.SaveChanges();
    }

    public List<KeyValuePair<int, decimal>> GetTotalConcretsAllOffer()
    {
        var result = new List<KeyValuePair<int, decimal>>();

        var offers = _context.Offers.ToList();

        foreach (var offer in offers)
        {
            var offerParts = _context.OfferParts.Where(x => x.OfferId == offer.Id).ToList();

            decimal totalGrossConcrete = 0;

            foreach (var offerPart in offerParts)
            {
                var offerCalculates = _context.OfferCalculates
                    .Where(x => x.OfferPartId == offerPart.Id)
                    .ToList();

                var partTotalGrossConcrete = offerCalculates
                    .Sum(x => x.NetConcreteTotal ?? 0); // GrossConcrete ile Price'ı çarpıp topla
                totalGrossConcrete += partTotalGrossConcrete;
            }
            result.Add(new KeyValuePair<int, decimal>(offer.Id, totalGrossConcrete));
        }
        return result;

    }

    public OfferPart GetByIdOfferPart(int id)
    {
        return _context.OfferParts.Where(x => x.Id == id).FirstOrDefault();
    }

    public void UpdateOfferPart(OfferPart offerPart)
    {
        var offer = _context.Offers.Where(x => x.Id == offerPart.OfferId).FirstOrDefault();
        decimal km = offer.Km;
        decimal egimK = offer.EgimKatsayi;
        decimal mesafeK = offer.MesafeKatsayisi;
        var nakliteBedeli = _context.OfferCostCalculateDetails.Where(x => x.OfferPartId == offerPart.Id && x.OfferMaterials.CurrentValue.CurrentValueName == "Akaryakıt Fiyatı");
        var akaryakitBedeli = _context.OfferCostCalculateDetails
            .Where(x => x.OfferPartId == offerPart.Id && x.OfferMaterials.CurrentValue.CurrentValueName == "Akaryakıt Fiyatı")
            .Select(x => x.CurrentValueC)
            .FirstOrDefault();
        decimal sonuc = km * 2 * 0.799m * mesafeK * akaryakitBedeli * 1.82m * egimK;
        decimal sonucDoly = km * 2 * 1.105m * mesafeK * akaryakitBedeli * 1.82m * egimK;

        decimal tirBedel = sonuc * offerPart.StandartTirAdet;
        decimal dolyBedel = sonucDoly * offerPart.DollyDorseAdet;

        decimal result = 0m;

        if (tirBedel == 0m)
        {
            result += 0m;
        }
        else
        {
            result += tirBedel < (1438m * 1.5m) ? (1438m * 1.5m) : tirBedel;
        }

        if (dolyBedel == 0m)
        {
            result += 0m;
        }
        else
        {
            result += dolyBedel < (1990m * 1.5m) ? (1990m * 1.5m) * offerPart.DollyDorseAdet : dolyBedel;
        }
        _context.OfferParts.Update(offerPart);
        _context.SaveChanges();
    }

    public OfferTerminSub UpdateOfferTerminSub(OfferTerminSub offerTerminSub)
    {
        foreach (var item in offerTerminSub.OfferTerminDetails)
        {
            if (item.Id == 0)
            {
                item.OfferTerminSubId = offerTerminSub.Id;
                if (item.ProjectElementTypeId == 0)
                {
                    continue;
                }
                _context.OfferTerminDetail.Add(item);
                _context.SaveChanges();
            }
            else
            {
                var det = _context.OfferTerminDetail.Where(x => x.Id == item.Id).FirstOrDefault();
                det.QuanTity = item.QuanTity;
                det.Length = item.Length;
                _context.OfferTerminDetail.Update(det);
                _context.SaveChanges();
            }
        }
        return offerTerminSub;
    }

    public void DeleteTerminDetay(int id)
    {
        var detay = _context.OfferTerminDetail.Where(x => x.Id == id).FirstOrDefault();
        _context.OfferTerminDetail.Remove(detay);
        _context.SaveChanges();
    }





    public async Task<string> ConfirmOffer(int offerId, bool confirm, string confirmDesc, string redDesc, string sozlesmeDosyasi,
    string sozlesmeDosyasiDiger, Dictionary<int, float> prices, decimal kdvOrani, decimal kdvDahil, decimal grTutar, string userId, decimal tevkifatOrani, DateTime projeTerminTarihi)
    {
        var offer = await _context.Offers.Where(x => x.Id == offerId).FirstOrDefaultAsync();
        if (offer == null)
        {
            throw new Exception("Offer not found");
        }
        if (!offer.ContractConfirm && confirm)
        {
            offer.SendProject = true;
            offer.ContractConfirm = true;

            offer.Code += "-" + DateTime.Now.Year.ToString().Substring(2, 2) + "-" +
                _context.Offers.Count(x => x.ContractConfirm == true).ToString("000") + "/0";
        }
        offer.ContractConfirm = confirm;
        offer.ContractRed = !confirm;
        offer.ContractConfirmDesc = confirmDesc;
        offer.ContractConfirmRedDesc = redDesc;
        offer.TevkifatOrani = tevkifatOrani;
        offer.ProjeTerminTarihi = projeTerminTarihi;
        if (!string.IsNullOrEmpty(sozlesmeDosyasi))
        {

            offer.ContractConfirmFile = sozlesmeDosyasi;
        }
        if (!string.IsNullOrEmpty(sozlesmeDosyasiDiger))
        {
            offer.ContractConfirmFileOther = sozlesmeDosyasiDiger;

        }
        foreach (var item in prices)
        {
            var part = _context.OfferParts.Where(x => x.Id == item.Key).FirstOrDefault();
            if (part != null)
            {
                part.SozlesmeTutari = Convert.ToDecimal(item.Value);
            }
            _context.OfferParts.Update(part);
            _context.SaveChanges();
        }
        ProjectModuleSub projectModuleSub = _context.ProjectModuleSub.Where(x => x.OfferId == offerId).FirstOrDefault();
        if (projectModuleSub == null)
        {
            projectModuleSub = new ProjectModuleSub();
            projectModuleSub.OfferId = offer.Id;
            projectModuleSub.Name = offer.Name;
            _context.ProjectModuleSub.Add(projectModuleSub);
            _context.SaveChanges();
        }
        offer.ContractConfirmPriceKdvOrani = kdvOrani;
        offer.ContractConfirmPriceKdvDahil = kdvDahil;
        offer.ContractConfirmPriceGR = grTutar;


        _context.Offers.Update(offer);
        await _context.SaveChangesAsync();

        var currentProcess = offerProcessService.Where(x => x.OfferId == offerId && x.IsActive == true).FirstOrDefault();
        if (currentProcess != null)
        {
            currentProcess.IsActive = false;
            currentProcess.EndTime = DateTime.Now;
            currentProcess.StarterUserId = userId;
            currentProcess.ResponsibleUserId = userId;

            _context.OfferProcess.Update(currentProcess);
            await _context.SaveChangesAsync();
        }

        var newProcess = new OfferProcess
        {
            OfferId = offerId,
            StartTime = DateTime.Now,
            EndTime = DateTime.Now,
            StarterUserId = userId,
            ResponsibleUserId = userId,
            IsActive = true,
            OfferProcessStage = confirm ? Domain.Enums.OfferProcessStage.MuseteriKabul : Domain.Enums.OfferProcessStage.MusteriRed
        };

        _context.OfferProcess.Add(newProcess);
        await _context.SaveChangesAsync();

        if (confirm)
        {
            var projectManagers = await userService.GetProjectYoneticiUsers();
            notificationService.SendNotificationGrup(userId, "Yeni Bir Sözleşme İmzalandı", "", projectManagers.ToList(), "Blue");
            // SendProjectModule(offerId, userId);
            return "Contract Confirmed";
        }
        else
        {
            return "Contract Rejected";
        }
    }

    public async void TopluIletisimeGecilmeyenSmsGonder(List<ApplicationUser> applicationUsers)
    {
        foreach (var user in applicationUsers)
        {
            var offers = _context.Offers.Where(x => x.ResponsibleUserId == user.Id).ToList();
            var offerMessages = new List<string>();

            foreach (var offer in offers)
            {
                var interaction = _context.CustomerInteractionOffers.FirstOrDefault(x => x.OfferId == offer.Id);
                if (interaction == null)
                {
                    offerMessages.Add($"{offer.Name} adlı {offer.Code} kodlu teklif");
                }
            }

            if (offerMessages.Any())
            {
                var client = new RestSharp.RestClient("https://api.vatansms.net/api/v1/1toN");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");

                string phones = user.Tel;
                string message = string.Join(", ", offerMessages) + " için hiç iletişime geçmediniz. Teklifleriniz için iletişime geçmeniz önemle rica olunur. Bu bir sistem otomatik mesajıdır.";

                var body = new
                {
                    api_id = "bc83386712b7f095162e56bc",
                    api_key = "e1edb2d40e51ecd7b7326753",
                    sender = "HrProject",
                    message_type = "normal",
                    message,
                    message_content_type = "bilgi",
                    phones = new string[] { phones }
                };

                request.AddJsonBody(body);

                IRestResponse response = await client.ExecuteAsync(request);
                // Handle the response if necessary
            }
        }
    }


    public void TopluIletisimeGecilmeyenSmsGonderYoneticilere(List<ApplicationUser> applicationUsers)
    {
        var offers = _context.Offers.ToList();
        List<string> tekliflerGecilmeyen = new List<string>();
        int sayac = 0;

        foreach (var teklif in offers)
        {
            var iletisimler = _context.CustomerInteractionOffers.FirstOrDefault(x => x.OfferId == teklif.Id);
            if (iletisimler == null)
            {
                sayac++;
            }
        }
        foreach (var item in applicationUsers)
        {


            var client = new RestSharp.RestClient("https://api.vatansms.net/api/v1/1toN");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            string message = $"{DateTime.Now.ToString()} Tarihi itibari ile iletişime geçmediğiniz toplam {sayac} adet teklif bulunmaktadır. Sayın Yönetici Bilginize sunarız. ERP ELF OTOMATİK MESAJIDIR.";
            string phones = item.Tel;

            var body = new
            {
                api_id = "bc83386712b7f095162e56bc",
                api_key = "e1edb2d40e51ecd7b7326753",
                sender = "HrProject",
                message_type = "normal",
                message,
                message_content_type = "bilgi",
                phones = new string[] { phones }
            };

            request.AddJsonBody(body);

            IRestResponse response = client.Execute(request);

            sayac++;
            // Response handling if necessary
        }
    }

    public void IletisimHatirlat(int offerId)
    {
        var offer = GetOfferIncludeById(offerId);
        var iletisimler = _context.CustomerInteractionOffers.FirstOrDefault(x => x.OfferId == offerId);
        var user = _context.Users.Where(x => x.Id == offer.ResponsibleUserId).FirstOrDefault();
        if (!offer.ContractRed && !offer.ContractConfirm)
        {
            var client = new RestSharp.RestClient("https://api.vatansms.net/api/v1/1toN");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            string message = offer.Name + " teklifi için hiç iletişime geçmediniz. Teklifleriniz için iletişime geçmeniz önemle rica olunur. Bu bir sistem otomatik mesajıdır.";
            string phones = user.Tel;

            var body = new
            {
                api_id = "bc83386712b7f095162e56bc",
                api_key = "e1edb2d40e51ecd7b7326753",
                sender = "HrProject",
                message_type = "normal",
                message,
                message_content_type = "bilgi",
                phones = new string[] { phones }
            };

            request.AddJsonBody(body);

            IRestResponse response = client.Execute(request);

        }
    }

    public IEnumerable<Offer> GetOfferIncludeProjesiz(int sayfaNo, int sayfaBuyukluk, string code)
    {
        sayfaNo = sayfaNo <= 0 ? 1 : sayfaNo;
        sayfaBuyukluk = sayfaBuyukluk <= 0 ? 10 : sayfaBuyukluk;

        int skip = (sayfaNo - 1) * sayfaBuyukluk;

        var query = _context.Offers.AsNoTracking()
     .Include(x => x.City)
     .Include(x => x.ApplicationUser)
     .Include(x => x.District)
     .Include(x => x.ResponsibleUser)
     .Include(x => x.CariKart)
     .Select(o => new Offer
     {
         Id = o.Id,
         LengthOfTerm = o.LengthOfTerm,
         LengthOfTermProject = o.LengthOfTermProject,
         LengthOfTermCalculate = o.LengthOfTermCalculate,
         Adress = o.Adress,
         SendProject = o.SendProject,
         Kilit = o.Kilit,
         ProjectPrice = o.ProjectPrice,
         Explanation = o.Explanation,
         DescResponseCalculate = o.DescResponseCalculate,
         DescResponseProject = o.DescResponseProject,
         Name = o.Name,
         OfferCode = o.OfferCode,
         Code = o.Code,
         PlotNumber = o.PlotNumber,
         ParcelNumber = o.ParcelNumber,
         ExchangeRate = o.ExchangeRate,
         Overheads = o.Overheads,
         Inflation = o.Inflation,
         CariKartId = o.CariKartId,
         CariKart = o.CariKart,
         CityId = o.CityId,
         City = o.City,
         DistrictId = o.DistrictId,
         District = o.District,
         NeighbourhoodId = o.NeighbourhoodId,
         Neighbourhood = o.Neighbourhood,
         ApplicationUserId = o.ApplicationUserId,
         ApplicationUser = o.ApplicationUser,
         ResponsibleUserId = o.ResponsibleUserId,
         ResponsibleUser = o.ResponsibleUser,
         ProjectResponsibleUserId = o.ProjectResponsibleUserId,
         ProjectResponsibleUser = o.ProjectResponsibleUser,
         OfferCalculateConfirm = o.OfferCalculateConfirm,
         ContractConfirm = o.ContractConfirm,
         ContractRed = o.ContractRed,
         ContractConfirmPriceKdvOrani = o.ContractConfirmPriceKdvOrani,
         ContractConfirmPriceKdvDahil = o.ContractConfirmPriceKdvDahil,
         ContractConfirmPriceGR = o.ContractConfirmPriceGR,
         Revize = o.Revize,
         Km = o.Km,
         TevkifatOrani = o.TevkifatOrani,
         EgimKatsayi = o.EgimKatsayi,
         MesafeKatsayisi = o.MesafeKatsayisi,
         MetrekupSatis = o.MetrekupSatis,
         MektreKareSatis = o.MektreKareSatis,
         VkAdetSatis = o.VkAdetSatis,
         CpSatis = o.CpSatis,
         ProjeTerminTarihi = o.ProjeTerminTarihi,
         OfferParts = o.OfferParts.ToList(),
         OfferProcess = o.OfferProcess.ToList(),
         OfferProjectDocuments = o.OfferProjectDocuments.ToList(),
         OfferTechnicalByOffers = o.OfferTechnicalByOffers.ToList(),
     });

        if (!string.IsNullOrEmpty(code))
        {
            query = query.Where(o => o.Code.Contains(code) || o.Name.Contains(code) || o.CariKart.Title.Contains(code));
        }

        query = query.OrderByDescending(o => o.Id);

        var result = query.Skip(skip)
                          .Take(sayfaBuyukluk)
                          .ToList();

        return result;



    }


    public int TeklifSayisi()
    {
        int teklifSayisi = _context.Offers.Count();
        return teklifSayisi;
    }

    public int GetCustomerOkOfferCount()
    {
        return _context.Offers.Include(x => x.OfferProcess)
           .Where(o => o.OfferProcess.Any(op => op.OfferProcessStage == Domain.Enums.OfferProcessStage.MuseteriKabul))
           .Count();
    }

    public int GetCustomerRedOfferCount()
    {
        return _context.Offers.Include(x => x.OfferProcess)
           .Where(o => o.OfferProcess.Any(op => op.OfferProcessStage == Domain.Enums.OfferProcessStage.MusteriRed))
           .Count();
    }

    public int AllTeklifSayisi()
    {
        int teklifSayisi = _context.Offers.Count();
        return teklifSayisi;
    }

    public string DeleteOffer(int offerId)
    {
        try
        {
            var offer = _context.Offers.Where(x => x.Id == offerId).FirstOrDefault();
            var offerProccess = _context.OfferProcess.Where(x => x.OfferId == offerId).ToList();
            _context.RemoveRange(offerProccess);
            _context.Remove(offer);
            _context.SaveChanges();
            return "İşlem Başarılı";
        }
        catch (Exception)
        {

            return "İşlem Başarısız";
        }



    }

    public List<string> OfferIdNameCodeTerminTarihi()
    {
        try
        {
            var teklifler = _context.Offers
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.Code,
                    x.ProjeTerminTarihi
                })
                .ToList(); // Verileri belleğe alıyoruz

            var result = teklifler.Select(x =>
            {
                // Daha güvenli bir ayırıcı karakter kullanarak string oluşturuyoruz
                var offerString = $"{x.Id} | {x.Name} | {x.Code} | {x.ProjeTerminTarihi.ToString("yyyy-MM-dd")}";

                // Her bir teklif için ProjectModuleSub olup olmadığını kontrol ediyoruz
                var projectModuleSub = _context.ProjectModuleSub
                    .Where(y => y.OfferId == x.Id)
                    .Select(y => new
                    {
                        y.UretimOnay,
                        y.StartProjectTime
                    })
                    .FirstOrDefault();

                if (projectModuleSub != null)
                {
                    var uretimeGonderildi = projectModuleSub.UretimOnay ? "Üretime Gönderildi" : "Üretime Gönderilmedi";
                    var baslangicZamani = projectModuleSub.StartProjectTime != null
                        ? projectModuleSub.StartProjectTime.ToString("yyyy-MM-dd HH:mm:ss")
                        : "Başlangıç Zamanı Yok";

                    offerString += $" | {uretimeGonderildi} | Başlangıç Zamanı: {baslangicZamani}";
                }
                else
                {
                    offerString += " | No Project Module";
                }

                return offerString;
            }).ToList();

            return result;
        }
        catch (Exception ex)
        {
            throw new Exception("OfferIdNameCodeTerminTarihi metodunda bir hata oluştu.", ex);
        }
    }

    public IEnumerable<Offer> GetOfferOnayBekleyenler()
    {
        var onayBekleyenler = _context.Offers.Include(x => x.OfferProcess)
            .Where(o => o.OfferProcess.Any(p => p.OfferProcessStage == Domain.Enums.OfferProcessStage.YoneticiOnayinaGonderildi && p.IsActive))
            .ToList();
        foreach (var item in onayBekleyenler)
        {
            foreach (var pros in item.OfferProcess)
            {
                pros.Offer = null;
            }
        }
        return onayBekleyenler;

    }

    public Offer GetByIdWithParts(int id)
    {
        var teklif = _context.Offers.Where(x => x.Id == id).Include(x => x.OfferParts).FirstOrDefault();
        foreach (var item in teklif.OfferParts)
        {
            item.Offer = null;
        }
        return teklif;
    }

    public async Task TeklifOnaylaYonetici(int id, string userId)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var offer = await _context.Offers
                    .Include(x => x.OfferProcess)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (offer == null)
                {
                    throw new Exception("Teklif bulunamadı");
                }

                var offerProcessOld = await _context.OfferProcess
                    .FirstOrDefaultAsync(x => x.OfferId == id && x.OfferProcessStage == Domain.Enums.OfferProcessStage.YoneticiOnayinaGonderildi);

                if (offerProcessOld != null)
                {
                    offerProcessOld.EndTime = DateTime.Now;
                    offerProcessOld.IsActive = false;
                    _context.Update(offerProcessOld);
                }
                var yeni = await _context.OfferProcess
                    .FirstOrDefaultAsync(x => x.OfferId == id && x.OfferProcessStage == Domain.Enums.OfferProcessStage.YoneticiOnayladi);
                if (yeni == null)
                {
                    var newOfferProcess = new OfferProcess
                    {
                        OfferId = id,
                        OfferProcessStage = Domain.Enums.OfferProcessStage.YoneticiOnayladi,
                        StarterUserId = userId,
                        CreatedTime = DateTime.Now,
                        IsActive = true,
                        ResponsibleUserId = userId,
                        StartTime = DateTime.Now
                    };
                    await _context.OfferProcess.AddAsync(newOfferProcess);
                }


                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                // Hata oluşursa transaction'ı geri al
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    public List<Offer> GetOfferJsonMobile(int sayfaNo, int adet)
    {
        if (sayfaNo == 0)
        {
            sayfaNo = 1;
        }
        int skip = (sayfaNo - 1) * adet;

        var offers = _context.Offers
            .OrderByDescending(o => o.Id)
            .Skip(skip) // Belirtilen sayıda teklifi atla
            .Take(adet) // Belirtilen sayıda teklif al
            .ToList(); // Sonuçları liste olarak al

        return offers;
    }

    public IEnumerable<Offer> GetOfferMusteriBilgiIzleme()
    {
        return _context.Offers
                   .Include(x => x.City)
                   .Include(x => x.ApplicationUser)
                   .Include(x => x.District)
                   .Include(x => x.OfferProcess)
                   .Include(x => x.ResponsibleUser)
                   .Include(x => x.CariKart)
                   .Select(x => new Offer
                   {
                       Id = x.Id,
                       LengthOfTerm = x.LengthOfTerm,
                       LengthOfTermProject = x.LengthOfTermProject,
                       LengthOfTermCalculate = x.LengthOfTermCalculate,
                       Adress = x.Adress,
                       SendProject = x.SendProject,
                       Kilit = x.Kilit,
                       ProjectPrice = x.ProjectPrice,
                       Explanation = x.Explanation,
                       DescResponseCalculate = x.DescResponseCalculate,
                       DescResponseProject = x.DescResponseProject,
                       FirstDrawFileName = x.FirstDrawFileName,
                       FirstDrawUzanti = x.FirstDrawUzanti,
                       Name = x.Name,
                       OfferCode = x.OfferCode,
                       Code = x.Code,
                       PlotNumber = x.PlotNumber,
                       ParcelNumber = x.ParcelNumber,
                       ExchangeRate = x.ExchangeRate,
                       Overheads = x.Overheads,
                       Inflation = x.Inflation,
                       CariKartId = x.CariKartId,
                       CariKart = x.CariKart,
                       CityId = x.CityId,
                       City = x.City,
                       DistrictId = x.DistrictId,
                       District = x.District,
                       NeighbourhoodId = x.NeighbourhoodId,
                       Neighbourhood = x.Neighbourhood,
                       ApplicationUserId = x.ApplicationUserId,
                       ApplicationUser = x.ApplicationUser,
                       ResponsibleUserId = x.ResponsibleUserId,
                       ResponsibleUser = x.ResponsibleUser,
                       ProjectResponsibleUserId = x.ProjectResponsibleUserId,
                       ProjectResponsibleUser = x.ProjectResponsibleUser,
                       OfferCalculateConfirm = x.OfferCalculateConfirm,
                       ContractConfirm = x.ContractConfirm,
                       ContractRed = x.ContractRed,
                       ContractConfirmDesc = x.ContractConfirmDesc,
                       ContractConfirmRedDesc = x.ContractConfirmRedDesc,
                       ContractConfirmFile = x.ContractConfirmFile,
                       ContractConfirmFileOther = x.ContractConfirmFileOther,
                       ContractConfirmPrice = x.ContractConfirmPrice,
                       ContractConfirmPriceKdvOrani = x.ContractConfirmPriceKdvOrani,
                       ContractConfirmPriceKdvDahil = x.ContractConfirmPriceKdvDahil,
                       ContractConfirmPriceGR = x.ContractConfirmPriceGR,
                       MesafeKatsayisi = x.MesafeKatsayisi,
                       ProjeTerminTarihi = x.ProjeTerminTarihi,
                   })
                   .ToList();
    }

    public Offer GetByIdCariKart(int id)
    {
        return _context.Offers.Where(x => x.Id == id).Include(x => x.CariKart).FirstOrDefault();
    }

    public Offer GetOfferIncludeByIdProjesiz(int id)
    {


        var query = _context.Offers.AsNoTracking()
     .Include(x => x.City)
     .Include(x => x.ApplicationUser)
     .Include(x => x.District)
     .Include(x => x.ResponsibleUser)
     .Include(x => x.CariKart)
     .Select(o => new Offer
     {
         Id = o.Id,
         LengthOfTerm = o.LengthOfTerm,
         LengthOfTermProject = o.LengthOfTermProject,
         LengthOfTermCalculate = o.LengthOfTermCalculate,
         Adress = o.Adress,
         SendProject = o.SendProject,
         Kilit = o.Kilit,
         ProjectPrice = o.ProjectPrice,
         Explanation = o.Explanation,
         DescResponseCalculate = o.DescResponseCalculate,
         DescResponseProject = o.DescResponseProject,
         Name = o.Name,
         OfferCode = o.OfferCode,
         Code = o.Code,
         PlotNumber = o.PlotNumber,
         ParcelNumber = o.ParcelNumber,
         ExchangeRate = o.ExchangeRate,
         Overheads = o.Overheads,
         Inflation = o.Inflation,
         CariKartId = o.CariKartId,
         CariKart = o.CariKart,
         CityId = o.CityId,
         City = o.City,
         DistrictId = o.DistrictId,
         District = o.District,
         NeighbourhoodId = o.NeighbourhoodId,
         Neighbourhood = o.Neighbourhood,
         ApplicationUserId = o.ApplicationUserId,
         ApplicationUser = o.ApplicationUser,
         ResponsibleUserId = o.ResponsibleUserId,
         ResponsibleUser = o.ResponsibleUser,
         ProjectResponsibleUserId = o.ProjectResponsibleUserId,
         ProjectResponsibleUser = o.ProjectResponsibleUser,
         OfferCalculateConfirm = o.OfferCalculateConfirm,
         ContractConfirm = o.ContractConfirm,
         ContractRed = o.ContractRed,
         ContractConfirmPriceKdvOrani = o.ContractConfirmPriceKdvOrani,
         ContractConfirmPriceKdvDahil = o.ContractConfirmPriceKdvDahil,
         ContractConfirmPriceGR = o.ContractConfirmPriceGR,
         Revize = o.Revize,
         Km = o.Km,
         TevkifatOrani = o.TevkifatOrani,
         EgimKatsayi = o.EgimKatsayi,
         MesafeKatsayisi = o.MesafeKatsayisi,
         MetrekupSatis = o.MetrekupSatis,
         MektreKareSatis = o.MektreKareSatis,
         VkAdetSatis = o.VkAdetSatis,
         CpSatis = o.CpSatis,
         ProjeTerminTarihi = o.ProjeTerminTarihi,
         OfferParts = o.OfferParts.ToList(),
         OfferProcess = o.OfferProcess.ToList(),
         OfferProjectDocuments = o.OfferProjectDocuments.ToList(),
         OfferTechnicalByOffers = o.OfferTechnicalByOffers.ToList(),
     });

        return query.Where(x => x.Id == id).FirstOrDefault();
    }
}

