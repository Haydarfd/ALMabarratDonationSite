using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlMabarratDonationWebApp.Core.Entities;

[Table("DonationType")]
public partial class DonationType
{
    [Key]
    public int DonationTypeId { get; set; }

    [StringLength(100)]
    public string DonationTypeName { get; set; } = null!;

    [InverseProperty("DonationType")]
    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();
}
