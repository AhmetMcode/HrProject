using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class Menu : BaseEntity
    {

        public int FoodNameId { get; set; }
        public FoodName FoodName { get; set; }
        public DateTime DateTime { get; set; }
        public int PersonQuant { get; set; }
        public List<MenuDetails> MenuDetails { get; set; }
        public bool Completed { get; set; }

    }

}
