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

            CreateMap<Person, PersonCreateVM>().ReverseMap();
            CreateMap<PersonPermission, PersonDetailViewModel>().ReverseMap();

            CreateMap<UserUpdateViewModel, ApplicationUser>().ReverseMap();
            

        }
    }

}
