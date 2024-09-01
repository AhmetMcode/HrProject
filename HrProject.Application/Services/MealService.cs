using Microsoft.EntityFrameworkCore;
using HrProject.ApplicaitonContracts.Interfaces;
using HrProject.Domain.Entities;
using HrProject.Presentation.Data;
using HrProject.Repository.Base;

namespace HrProject.Application.Services
{
    public class MealService : BaseRepository<Meal>, IMealService
    {
        public MealService(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public IEnumerable<Meal> GetCategoryMealId(int mealId)
        {
            var meals = _context.Meals.Where(d => d.MealCategoryId == mealId).ToList();

            return meals;
        }

        public IEnumerable<Meal> GetIncludeMeal()
        {
            var result = _context.Meals.Include(x => x.MealCategory).Include(x => x.NewFoods).ThenInclude(x => x.Stock).Include(x => x.NewFoods).ThenInclude(x => x.Unit);
            return result;
        }


        public IEnumerable<NewFood> GetNewFoodsByMealId(int mealId)
        {
            var newFoods = _context.NewFoods
                                    .Include(nf => nf.Stock)
                                    .Include(nf => nf.Unit)
                                    .Where(nf => nf.MealId == mealId)
                                    .ToList();

            return newFoods;
        }

    }
}
