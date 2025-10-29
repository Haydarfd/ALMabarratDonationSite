using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlMabarratDonationWebApp.Core.Entities;

public partial class SponsorshipRequest
{
    [Key]
    public int Id { get; set; }

    [StringLength(450)]
    public string? AppUserId { get; set; }

    public string? AgeGroup { get; set; }

    public string? Gender { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Amount { get; set; }

    public DateTime RequestedOn { get; set; }

    public bool IsHandled { get; set; }

    public string? PaymentType { get; set; }

    public string? SponsorshipType { get; set; }

    [ForeignKey("AppUserId")]
    [InverseProperty("SponsorshipRequests")]
    public virtual AspNetUser? AppUser { get; set; }

    [InverseProperty("SponsorshipRequest")]
    public virtual ICollection<Sponsorship> Sponsorships { get; set; } = new List<Sponsorship>();
}
