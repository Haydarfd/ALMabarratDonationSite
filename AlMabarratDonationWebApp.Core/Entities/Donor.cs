using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlMabarratDonationWebApp.Core.Entities;

public partial class Donor
{
    [Key]
    public int Id { get; set; }

    [StringLength(450)]
    public string AppUserId { get; set; } = null!;

    [StringLength(200)]
    public string Address { get; set; } = null!;

    [StringLength(100)]
    public string City { get; set; } = null!;

    [StringLength(20)]
    public string PostalCode { get; set; } = null!;

    [StringLength(100)]
    public string Country { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? DeletionDate { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? DeletionReason { get; set; }

    [ForeignKey("AppUserId")]
    [InverseProperty("Donors")]
    public virtual AspNetUser AppUser { get; set; } = null!;

    [InverseProperty("Donor")]
    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    [InverseProperty("Recipient")]
    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    [InverseProperty("Donor")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [InverseProperty("Donor")]
    public virtual ICollection<Sponsorship> Sponsorships { get; set; } = new List<Sponsorship>();
}
