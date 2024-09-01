using HrProject.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrProject.Domain.Entities
{
    public class RopeIronPm : BaseEntity
    {
        public int PmCalculateId { get; set; }
        public PmCalculate PmCalculate { get; set; }
        public ToronDiameter ToronDiameter { get; set; }
        public int ToronDiameterId { get; set; }
        public string? ToronDiameterCode { get; set; }
        public decimal? RopeIronKg { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal? RopeIronKgTotal { get; set; }
    }
}
