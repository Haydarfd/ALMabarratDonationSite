using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlMabarratDonationWebApp.Core.Entities;

[Table("Orphan")]
public partial class Orphan
{
    [Key]
    public int OrphanID { get; set; }

    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DateOfBirth { get; set; }

    [StringLength(10)]
    public string Gender { get; set; } = null!;

    [StringLength(50)]
    public string? LostParents { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateJoined { get; set; }

    [StringLength(100)]
    public string? FatherName { get; set; }

    [StringLength(100)]
    public string? MotherName { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsSponsored { get; set; }

    [StringLength(100)]
    public string? Nationality { get; set; }

    [StringLength(255)]
    public string? HealthCondition { get; set; }

    [StringLength(100)]
    public string? SponsorshipType { get; set; }

    public int? Age { get; set; }

    [InverseProperty("Orphan")]
    public virtual ICollection<Sponsorship> Sponsorships { get; set; } = new List<Sponsorship>();
}
