using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface INewFoodService : IBaseRepository<NewFood>
    {
        IEnumerable<NewFood> GetIncludeNewFood();

    }
}
