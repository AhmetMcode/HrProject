using HrProject.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrProject.Domain.Entities;

public class RopeIron : BaseEntity
{
    public int OfferCalculateId { get; set; }
    public OfferCalculate OfferCalculate { get; set; }
    public int Price { get; set; }
    public decimal Length { get; set; }
    [Column(TypeName = "decimal(10,3)")]
    public decimal Weight { get; set; }
    public int ToronDiameterId { get; set; }
    public ToronDiameter ToronDiameter { get; set; }
}
public class PmRopeIron : BaseEntity
{
    public int PmCalculateId { get; set; }
    public PmCalculate PmCalculate { get; set; }
    public int Price { get; set; }
    public decimal Length { get; set; }
    [Column(TypeName = "decimal(10,3)")]
    public decimal Weight { get; set; }
    public int ToronDiameterId { get; set; }
    public ToronDiameter ToronDiameter { get; set; }
}

