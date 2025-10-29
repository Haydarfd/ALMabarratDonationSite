using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlMabarratDonationWebApp.Core.Entities;

public partial class Event
{
    [Key]
    public int EventID { get; set; }

    [StringLength(100)]
    public string? TitleEN { get; set; }

    [StringLength(100)]
    public string? TitleAR { get; set; }

    public string? DescriptionEN { get; set; }

    public string? DescriptionAR { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EventDate { get; set; }

    [StringLength(255)]
    public string? Location { get; set; }

    [StringLength(100)]
    public string? Organizer { get; set; }

    public string? MediaURLs { get; set; }
}
