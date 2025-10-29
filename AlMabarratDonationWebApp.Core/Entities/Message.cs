using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlMabarratDonationWebApp.Core.Entities;

public partial class Message
{
    [Key]
    public int MessageID { get; set; }

    [StringLength(100)]
    public string? FullName { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    [StringLength(20)]
    public string? PhoneNumber { get; set; }

    [StringLength(255)]
    public string? Subject { get; set; }

    [Column("Message")]
    public string? Message1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateReceived { get; set; }

    [StringLength(20)]
    public string? Status { get; set; }
}
