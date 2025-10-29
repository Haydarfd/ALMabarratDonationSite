using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlMabarratDonationWebApp.Core.Entities;

[Table("Campaign")]
public partial class Campaign
{
    [Key]
    public int CampaignID { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    public string Category { get; set; } = null!;

    public string? Description { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal TargetAmount { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal? CurrentAmount { get; set; }

    [StringLength(50)]
    public string? Country { get; set; }

    public string? MediaURLs { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
