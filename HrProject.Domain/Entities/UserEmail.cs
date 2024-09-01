using HrProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Domain.Entities
{
    public class UserEmail : BaseEntity
    {
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public string host { get; set; }
        public string Baslik { get; set; }
        public int gondermeport { get; set; }
        public int almaport { get; set; }
    }
}
