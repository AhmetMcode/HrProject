using HrProject.Domain.Entities.Base;
using HrProject.Domain.Enums;

namespace HrProject.Domain.Entities
{
    public class OutWaybill2 : BaseEntity
    {
        public string Description { get; set; }
        public int CariKartId { get; set; }
        public CariKart CariKart { get; set; }
        public string? EntryInvoiceAdress { get; set; }

        public string? EntryPostaCode { get; set; }
        public int EntryDistrictId { get; set; }
        public District EntryDistrict { get; set; }
        public int EntryCityId { get; set; }
        public City EntryCity { get; set; }
        public string? ExitInvoiceAdress { get; set; }
        public string? ExitPostaCode { get; set; }
        public int ExitDistrictId { get; set; }
        public District ExitDistrict { get; set; }
        public int ExitCityId { get; set; }
        public City ExitCity { get; set; }
        public ShippingMethod ShippingMethod { get; set; }
        public DateTime EditDate { get; set; }
        public DateTime ActualDate { get; set; }
        public string? WaybillNo { get; set; }
        public List<OutWaybillChange> OutWaybillChanges { get; set; }
        public string? PersonelCars { get; set; }
        public string? PersonelNameDetails { get; set; }
        public string? TasiyiciCars { get; set; }
        public string? TasiyiciDriver { get; set; }
        public int? TasiyiciTC { get; set; }
        public string? KargoCompany { get; set; }
        public int? KargoTaxNumber { get; set; }
        public bool InWay { get; set; }


    }
}
