using Microsoft.AspNetCore.Mvc.Rendering;
using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IPersonPositionService : IBaseRepository<PersonPosition>
    {
        List<SelectListItem> GetPersonPositionsAsSelectListItems();
        string CreatePositionCode(PersonPosition personPosition);
    }
}
