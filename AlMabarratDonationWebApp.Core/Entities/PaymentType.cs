using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlMabarratDonationWebApp.Core.Entities;

[Table("PaymentType")]
public partial class PaymentType
{
    [Key]
    public int PaymentTypeId { get; set; }

    [StringLength(100)]
    public string PaymentName { get; set; } = null!;

    [InverseProperty("PaymentType")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
