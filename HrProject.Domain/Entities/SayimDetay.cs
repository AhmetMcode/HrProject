using System;
using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class SayimDetay : BaseEntity
    {
        public int StockId { get; set; } // ID of the stock item
        public Stock Stock { get; set; } // Stock entity reference
        public double Adet { get; set; } // Quantity of the stock item
        public DateTime SayimDetayTime { get; set; }

        public int SubSayimId { get; set; } // Foreign key to SubSayim
        public SubSayim SubSayim { get; set; } // Reference to the related SubSayim
    }
}

