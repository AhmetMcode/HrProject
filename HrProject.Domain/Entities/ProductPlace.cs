using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class ProductPlace : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Lengt { get; set; }
        public int Width { get; set; }
    }
}
