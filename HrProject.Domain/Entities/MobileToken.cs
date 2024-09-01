using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class MobileToken : BaseEntity
    {
        public string? UserId { get; set; }
        public string? Token { get; set; }
    }
}
