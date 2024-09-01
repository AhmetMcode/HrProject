using System;
using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class ManualStockEntry : BaseEntity
    {
        public int StockId { get; set; }
        public Stock Stock { get; set; }
        public int Quantity { get; set; }
        public DateTime EntryDate { get; set; }
        public string RecordedBy { get; set; }  // Username or UserId of the person who made the entry
        // Yeni eklenen özellik
        public string ActionType { get; set; }  // "set", "increase", "decrease"
    }
}

