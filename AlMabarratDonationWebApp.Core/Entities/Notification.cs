using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlMabarratDonationWebApp.Core.Entities;

[Table("Notification")]
public partial class Notification
{
    [Key]
    public int NotificationId { get; set; }

    [StringLength(255)]
    public string Title { get; set; } = null!;

    public string Message { get; set; } = null!;

    public int RecipientId { get; set; }

    public int NotificationTypeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateRead { get; set; }

    public bool IsRead { get; set; }

    public bool IsActive { get; set; }

    [ForeignKey("NotificationTypeId")]
    [InverseProperty("Notifications")]
    public virtual NotificationType NotificationType { get; set; } = null!;

    [ForeignKey("RecipientId")]
    [InverseProperty("Notifications")]
    public virtual Donor Recipient { get; set; } = null!;
}
