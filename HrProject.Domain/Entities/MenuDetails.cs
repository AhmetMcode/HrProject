using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class MenuDetails : BaseEntity
    {
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public Meal Meal { get; set; }
        public int MealId { get; set; }
    }
}
