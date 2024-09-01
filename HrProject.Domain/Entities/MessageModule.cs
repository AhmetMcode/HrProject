using HrProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HrProject.Domain.Entities
{
    public class MessageModule : BaseEntity
    {
        public ApplicationUser Gonderen { get; set; }
        public string GonderenId { get; set; }
        public DateTime GonderilmeZamani { get; set; }
        public string? Mesaj { get; set; }
        public bool Belge { get; set; }
        public bool GrupMesajı { get; set; }
        public string? BelgeBase64 { get; set; }
        public string? BelgeAdi { get; set; }
        public string? BelgeBaseUzanti { get; set; }

        public ApplicationUser Alan { get; set; }
        public string? AlanId { get; set; }


        public bool Iletildi { get; set; }
        public bool Goruldu { get; set; }
    }
}
