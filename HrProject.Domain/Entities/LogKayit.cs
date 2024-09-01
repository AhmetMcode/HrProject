using HrProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Domain.Entities
{
    public class LogKayit : BaseEntity
    {
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public string YapilanIslem { get; set; }
        public string? IpAdresi { get; set; }
        public DateTime GerceklesmeZamani { get; set; }
        public string? MobilWeb { get; set; }
    }
}
