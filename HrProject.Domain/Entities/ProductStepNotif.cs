using Microsoft.AspNetCore.Identity;
using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class ProductStepNotif : BaseEntity
    {
        public string IdentityRoleId { get; set; }
        public IdentityRole IdentityRole { get; set; }
        public int ProductionStepId { get; set; }
        public ProductionStep ProductionStep { get; set; }
        public string? BildirimIcerik { get; set; }
        public string? BildirimBaslik { get; set; }
        public bool Mail { get; set; }
        public bool Mobil { get; set; }
        public bool Web { get; set; }
        public bool Sms { get; set; }
    }
}
