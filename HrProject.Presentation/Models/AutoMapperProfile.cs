using AutoMapper;
using HrProject.Domain.Entities;
using HrProject.Domain.Entities.Base;
using HrProject.Presentation.ViewModels;
namespace HrProject.Presentation.Models
{

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddCariKartViewModel, CariKart>();
            CreateMap<CariKart, AddCariKartViewModel>();
            CreateMap<CariKart, EditCariKartViewModel>();
            CreateMap<CariRisk, EditCariKartViewModel>();
            CreateMap<EditCariKartViewModel, CariRisk>();
            CreateMap<EditCariKartViewModel, CariKart>();
            CreateMap<EditCariKartViewModel, CariBank>();
            CreateMap<InvoiceAdress, EditCariKartViewModel>();
            CreateMap<EditCariKartViewModel, InvoiceAdress>();
            CreateMap<OfferViewModel, Offer>();
            CreateMap<Offer, OfferViewModel>();
            CreateMap<OfferAddDocument, OfferProjectDocuments>().ReverseMap();
            CreateMap<Stock, StockViewModel>().ReverseMap();
            CreateMap<Person, PersonCreateVM>().ReverseMap();
            CreateMap<PersonPermission, PersonDetailViewModel>().ReverseMap();
            CreateMap<ProjectElementTypeListAndAddViewModel, ProjectElementType>().ReverseMap();
            CreateMap<OfferCostCategory, ALOfferCostCategory>().ReverseMap();
            CreateMap<OfferMaterials, ALOfferMaterials>().ReverseMap();
            CreateMap<UserUpdateViewModel, ApplicationUser>().ReverseMap();
            CreateMap<FirstOffer, FirstOfferViewModel>().ReverseMap();
            CreateMap<DetailOffer, DetailOfferViewModel>().ReverseMap();
            CreateMap<StockChange, StockChangeViewModel>().ReverseMap();
            CreateMap<StockMove, StockMoveViewModel>().ReverseMap();
            CreateMap<MoneyTransfer, MoneyTransferViewModel>().ReverseMap();
            CreateMap<Checks, ChecksViewModel>().ReverseMap();
            CreateMap<VisitorEntry, VisitorViewModel>().ReverseMap();
            CreateMap<Meal, MealViewModel>().ReverseMap();
            CreateMap<Menu, MealViewModel>().ReverseMap();
            CreateMap<OfferCostCalculateDetail, OfferCostCalculateDetailJson>().ReverseMap();
            CreateMap<Vehicle, VehicleViewModel>().ReverseMap();
            CreateMap<FuelTransfer, FuelTransferViewModel>().ReverseMap();
            CreateMap<MaintenanceRequest, MaintenanceRequestViewModel>().ReverseMap();
            CreateMap<MaintenanceService, MaintenanceServiceViewModel>().ReverseMap();
            CreateMap<HesapPlani, HesapViewModel1>().ReverseMap();
            CreateMap<Invoice, InvoiceViewModel>().ReverseMap();
            CreateMap<HesapMuavin, HesapViewModel2>().ReverseMap();
            CreateMap<Stock, StockDataModel>().ReverseMap();

        }
    }

}
