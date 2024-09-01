using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrProject.Domain.Entities.Base;

namespace HrProject.Domain.Entities
{
    public class FileProjeModul : BaseEntity
    {
        public int? ProjectModuleSubId { get; set; }
        public ProjectModuleSub ProjectModuleSub { get; set; }
        public int? ProjectElementId { get; set; }
        public ProjectElement ProjectElement { get; set; }
        public string Ad { get; set; }
        public string Dosya { get; set; }
        public string Uzanti { get; set; }
        public int RevizeNo { get; set; }
    }
}
