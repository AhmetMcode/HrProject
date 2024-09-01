using HrProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Domain.Entities
{
    public class PersAddDoc : BaseEntity
    {
        public int PersonelDocumentId { get; set; }
        public PersonelDocument PersonelDocument { get; set; }
        public DateTime SigningDate { get; set; }
        public string SigningDocument { get; set; }
    }
}
