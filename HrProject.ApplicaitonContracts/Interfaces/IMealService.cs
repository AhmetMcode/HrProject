using HrProject.Domain.Entities;
using HrProject.Repository.Repositories.Interfaces;

namespace HrProject.ApplicaitonContracts.Interfaces
{
    public interface IMealService : IBaseRepository<Meal>
    {
        IEnumerable<Meal> GetIncludeMeal();

        IEnumerable<Meal> GetCategoryMealId(int mealId);

        IEnumerable<NewFood> GetNewFoodsByMealId(int mealId);
    }
}
