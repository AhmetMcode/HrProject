using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class City : BaseEntity
    {


        public string Name { get; set; }
        public string? Code { get; set; }
        public string? TcpsCode { get; set; }
    }
}
