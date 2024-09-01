using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class LastActivity : BaseEntity
    {
        public string Renk { get; set; }
        public string Icerik { get; set; }
        public string? Url { get; set; }
        public string? Role { get; set; }
    }
}
