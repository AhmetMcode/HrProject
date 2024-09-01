using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IOfferService : IBaseRepository<Offer>
    {

        IEnumerable<District> GetDistrictsByCityId(int cityId);
        IEnumerable<Neighbourhood> GetNeighbourhoodByDistrictId(int districtId);
        IEnumerable<Offer> GetOfferInclude();
        IEnumerable<Offer> GetOfferMusteriBilgiIzleme();
        IEnumerable<Offer> GetOfferOnayBekleyenler();
        IEnumerable<Offer> GetOfferIncludeProjesiz(int sayfaNo, int sayfaBuyukluk, string code);
        Offer GetOfferIncludeByIdProjesiz(int id);
        Offer GetOfferByPartId(int partId);
        Task<Offer> OfferAssignment(int offerId, string assignmentUserId, string assignerUserId, string projectUserId, DateTime hesapBitisi, DateTime projeBitisi, DateTime terminTarihi, string projeAtamaAciklama, string hesapAtamaAciklama);
        Offer GetOfferIncludeById(int id);
        OfferProjectDocuments GetOfferDocument(int offerId);
        void UpdateProjectDocuments(OfferProjectDocuments model);
        void TransferCalculate(int transferId, int calculateId);
        void SendCalculates(int offerId);
        Task SendProjectModule(int offerId, string userId);
        void UpdateDescParts(List<OfferPart> offerParts);
        Task<string> ConfirmOffer(int offerId, bool confirm, string confirmDesc, string redDesc, string sozlesmeDosyasi,
     string sozlesmeDosyasiDiger, Dictionary<int, float> prices, decimal kdvOrani, decimal kdvDahil, decimal grTutar, string userId, decimal tevkifatOrani, DateTime projeTerminTarihi);
        List<OfferCalculate> GetOfferCalculates(int offerId);
        List<OfferCalculate> GetOfferCalculatesByOfferId(int offerId);
        List<OfferCalculate> GetOfferPartCalculates(int offerId);
        List<OfferTechnicalByOffer> GetAndAddOfferTech(int offerId);
        List<OfferCalculate> GetOfferCalculateSimilar(int offerCalculateId);
        OfferCalculate GetOfferCalculate(int calculateId);
        void SaveOfferCalculates(List<OfferCalculate> offerCalculates);
        void SaveProjectDetail(ProjectElementDetails projectElementDetails, decimal netIron, decimal netIronTotal, decimal concrete, decimal concreteTotal);
        void DeleteProjectDetail(int id);
        void SaveWickerIronJson(List<WickerIronCalculate> wickerIronCalculate, decimal wi, decimal wiTotal);
        List<ProjectElementDetails> GetProjectDetail(int projectElementId);
        List<WickerIronCalculate> GetWickerIronCalculate(int offerCalculateId);
        void SaveRopeIrons(List<RopeIron> hasirIrons, decimal ropIron, decimal ropIronTotal);
        List<RopeIron> GetRopeIrons(int offerCalculateId);
        List<RopeIron> GetRopeByPartIdIrons(int offerPartId);
        List<OfferProcess> GetOfferProcess(int offerId);
        void SaveAnkrajIrons(List<AnkrajIron> hasirIrons, decimal ankraj, decimal ankrajTotal);
        void FinishCalculate(int offerId, string userId);
        void DeleteCalculate(int id);
        int ConfirmCalculates(int id);
        int TeklifSayisi();
        void ReloadCost(int offerPartId);
        Task UpdateTotalParts(List<OfferPart> offerParts, decimal ExchangeRate, decimal Overheads, decimal Inflation, Offer offer);
        Task UpdateOfferTechs(List<OfferTechnicalByOffer> offers);
        void UpdateInflation(int OfferId, decimal ExchangeRate, decimal Overheads, decimal Inflation);
        List<AnkrajIron> GetAnkrajIrons(int offerCalculateId);
        List<ConcreteClass> GetConcretsClass();
        List<ToronDiameter> GetTorons();
        List<KeyValuePair<string, decimal>> GetConcretsWithVaVlue(int offerId);
        List<KeyValuePair<int, decimal>> GetTotalConcretsAllOffer();
        decimal GetTotalIronValue(int offerId);
        decimal GetTotalWickerValue(int offerId);
        decimal GetTotalConcreteValue(int offerPartId);
        List<KeyValuePair<string, decimal>> GetRopeIronsTotalValue(int offerId);
        Task<List<KeyValuePair<string, string>>> GetReport();
        List<OfferPart> GetAndAddOfferParts(int offerId);
        OfferTerminSub GetAndAddOfferTerminSub(int offerId);
        OfferTerminSub GetOfferTerminSub(int offerId);
        OfferTerminSub UpdateOfferTerminSub(OfferTerminSub offerTerminSub);
        List<OfferTerminSub> GetAllOfferTerminSubBySend();
        OfferTerminSub UpdatePlanlamaTermin(OfferTerminSub offerTerminSub);
        OfferPart GetByIdOfferPart(int id);
        Offer GetByIdWithParts(int id);
        Offer GetByIdCariKart(int id);
        int GetCustomerOkOfferCount();
        int GetCustomerRedOfferCount();
        int AllTeklifSayisi();
        void UpdateOfferPart(OfferPart offerPart);
        void DeleteTerminDetay(int id);
        Task TeklifOnaylaYonetici(int id, string userId);
        string GenerateCode();
        void TopluIletisimeGecilmeyenSmsGonder(List<ApplicationUser> applicationUsers);
        void TopluIletisimeGecilmeyenSmsGonderYoneticilere(List<ApplicationUser> applicationUsers);
        void IletisimHatirlat(int offerId);
        string DeleteOffer(int offerId);
        List<string> OfferIdNameCodeTerminTarihi();
        List<Offer> GetOfferJsonMobile(int adet, int sayfaNo);

    }
}
