using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlMabarratDonationWebApp.Core.Entities;

[Table("Sponsorship")]
public partial class Sponsorship
{
    [Key]
    public int SponsorshipID { get; set; }

    public int? DonorID { get; set; }

    public int? OrphanID { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Amount { get; set; }

    public bool Status { get; set; }

    public int? SponsorshipRequestId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateAssigned { get; set; }

    [StringLength(100)]
    public string? SponsorshipType { get; set; }

    [StringLength(100)]
    public string? PaymentType { get; set; }

    [ForeignKey("DonorID")]
    [InverseProperty("Sponsorships")]
    public virtual Donor? Donor { get; set; }

    [ForeignKey("OrphanID")]
    [InverseProperty("Sponsorships")]
    public virtual Orphan? Orphan { get; set; }

    [ForeignKey("SponsorshipRequestId")]
    [InverseProperty("Sponsorships")]
    public virtual SponsorshipRequest? SponsorshipRequest { get; set; }
}
