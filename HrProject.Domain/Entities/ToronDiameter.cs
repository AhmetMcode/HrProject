using Microsoft.EntityFrameworkCore.Metadata.Internal;
using HrProject.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrProject.Domain.Entities
{
    public class ToronDiameter : BaseEntity
    {
        public string Code { get; set; }
        [Column(TypeName = "decimal(10,3)")]
        public decimal Value { get; set; }
    }
}
