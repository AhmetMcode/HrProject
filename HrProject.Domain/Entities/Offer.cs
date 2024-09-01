using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class Offer : BaseEntity
    {
        public DateTime? LengthOfTerm { get; set; }
        public DateTime? LengthOfTermProject { get; set; }
        public DateTime? LengthOfTermCalculate { get; set; }
        public string Adress { get; set; }
        public bool SendProject { get; set; }
        public bool Kilit { get; set; }
        public decimal? ProjectPrice { get; set; }
        public string? Explanation { get; set; }
        public string? DescResponseCalculate { get; set; }
        public string? DescResponseProject { get; set; }
        public string FirstDraw { get; set; }
        public string? FirstDrawFileName { get; set; }
        public string? FirstDrawUzanti { get; set; }
        public string Name { get; set; }
        public string? OfferCode { get; set; }
        public string? Code { get; set; }
        public int PlotNumber { get; set; }
        public string ParcelNumber { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal Overheads { get; set; }
        public decimal Inflation { get; set; }
        public int? CariKartId { get; set; }
        public CariKart? CariKart { get; set; }
        public int? CityId { get; set; }
        public City? City { get; set; }
        public int? DistrictId { get; set; }
        public District? District { get; set; }
        public int? NeighbourhoodId { get; set; }
        public Neighbourhood? Neighbourhood { get; set; }
        public string? ApplicationUserId { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public string? ResponsibleUserId { get; set; }
        public ApplicationUser? ResponsibleUser { get; set; }
        public string? ProjectResponsibleUserId { get; set; }
        public ApplicationUser? ProjectResponsibleUser { get; set; }
        public IEnumerable<OfferProcess>? OfferProcess { get; set; }
        public IEnumerable<OfferPart>? OfferParts { get; set; }
        public IEnumerable<OfferProjectDocuments>? OfferProjectDocuments { get; set; }
        public List<OfferTechnicalByOffer>? OfferTechnicalByOffers { get; set; }
        public bool OfferCalculateConfirm { get; set; }
        public bool ContractConfirm { get; set; }
        public bool ContractRed { get; set; }
        public string? ContractConfirmDesc { get; set; }
        public string? ContractConfirmRedDesc { get; set; }
        public string? ContractConfirmFile { get; set; }
        public string? ContractConfirmFileOther { get; set; }

        public decimal ContractConfirmPrice { get; set; }
        public decimal ContractConfirmPriceKdvOrani { get; set; }
        public decimal ContractConfirmPriceKdvDahil { get; set; }
        public decimal ContractConfirmPriceGR { get; set; }
        public int Revize { get; set; }
        public decimal Km { get; set; }
        public decimal TevkifatOrani { get; set; }
        public decimal EgimKatsayi { get; set; }
        public decimal MesafeKatsayisi { get; set; }
        public decimal MetrekupSatis { get; set; }
        public decimal MektreKareSatis { get; set; }
        public decimal VkAdetSatis { get; set; }
        public decimal CpSatis { get; set; }
        public DateTime ProjeTerminTarihi { get; set; }


    }
}
