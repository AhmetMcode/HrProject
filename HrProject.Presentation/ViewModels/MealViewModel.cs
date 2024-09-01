using HrProject.Domain.Entities;

namespace HrProject.Presentation.ViewModels
{
    public class MealViewModel
    {
        public int Id { get; set; }
        public List<NewFood> NewFoods { get; set; } = new List<NewFood>();
        public int MealCategoryId { get; set; }
        public MealCategory MealCategory { get; set; }
        public string Name { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public List<Meal> Meals { get; set; } = new List<Meal>();
        public DateTime DateTime { get; set; }
        public bool Completed { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public List<Menu> Menus { get; set; } = new List<Menu>();
        public List<MenuDetails> MenuDetails { get; set; }


    }


}
