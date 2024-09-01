using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IMenuService : IBaseRepository<Menu>
    {
        public List<Menu> GetMenuByDate(DateTime tarih);
        public void CompleteMealService(int mealId);
    }
}
