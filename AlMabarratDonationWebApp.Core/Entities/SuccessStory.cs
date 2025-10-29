using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlMabarratDonationWebApp.Core.Entities;

public partial class SuccessStory
{
    [Key]
    public int StoryID { get; set; }

    public int? OrphanID { get; set; }

    [StringLength(100)]
    public string? TitleEN { get; set; }

    [StringLength(100)]
    public string? TitleAR { get; set; }

    public string? DescriptionEN { get; set; }

    public string? DescriptionAR { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date { get; set; }

    [StringLength(255)]
    public string? ImageURL { get; set; }
}
