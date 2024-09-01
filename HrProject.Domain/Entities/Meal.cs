using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class Meal : BaseEntity
    {
        public string Name { get; set; }
        public int MealCategoryId { get; set; }
        public MealCategory MealCategory { get; set; }
        public List<NewFood> NewFoods { get; set; }
        public List<Menu> Menus { get; set; }
    }
}
