using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlMabarratDonationWebApp.Core.Entities;

[Table("Donation")]
public partial class Donation
{
    [Key]
    public int DonationId { get; set; }

    public int DonationTypeId { get; set; }

    public int DonorId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    [ForeignKey("DonationTypeId")]
    [InverseProperty("Donations")]
    public virtual DonationType DonationType { get; set; } = null!;

    [ForeignKey("DonorId")]
    [InverseProperty("Donations")]
    public virtual Donor Donor { get; set; } = null!;
}
