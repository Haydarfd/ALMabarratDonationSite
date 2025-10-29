using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlMabarratDonationWebApp.Core.Entities;

[Table("Payment")]
public partial class Payment
{
    [Key]
    public int PaymentId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Amount { get; set; }

    public int PaymentTypeId { get; set; }

    public int DonorId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    [ForeignKey("DonorId")]
    [InverseProperty("Payments")]
    public virtual Donor Donor { get; set; } = null!;

    [ForeignKey("PaymentTypeId")]
    [InverseProperty("Payments")]
    public virtual PaymentType PaymentType { get; set; } = null!;
}
