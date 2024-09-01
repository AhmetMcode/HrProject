using HrProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Domain.Entities
{
    public class ProjeDonatiRaporu : BaseEntity
    {
        public int ProjectModuleSubId { get; set; }
        public ProjectModuleSub ProjectModuleSub { get; set; }
        public IronDiameterWeight IronDiameterWeight { get; set; }
        public int IronDiameterWeightId { get; set; }
        public decimal Miktar { get; set; }
    }
}
