using Microsoft.AspNetCore.Mvc.Rendering;
using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IWorkPlaceService : IBaseRepository<Workplace>
    {
        List<SelectListItem> GetWorkPlaceAsSelectListItems();
    }
}
