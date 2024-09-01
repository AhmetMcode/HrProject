using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class NewFood : BaseEntity
    {
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public int StockId { get; set; }
        public Stock Stock { get; set; }
        public double Quantity { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public decimal? Calorie { get; set; }
    }
}
