using System;
using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class SubSayim : BaseEntity
    {
        public DateTime SayimTime { get; set; } // Time of the count
        public int DepoId { get; set; } // Warehouse ID
        public WareHouse Depo { get; set; } // Warehouse details
        public string ApplicationUserId { get; set; } // ID of the user who performed the count
        public ApplicationUser ApplicationUser { get; set; } // Details of the user who performed the count

        public List<SayimDetay> SayimDetaylar { get; set; } // Collection of related SayimDetay entries
        public bool IsSayimCompleted { get; set; }
    }
}
