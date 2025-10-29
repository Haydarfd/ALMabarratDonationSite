using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlMabarratDonationWebApp.Core.Entities;

[Table("NotificationType")]
public partial class NotificationType
{
    [Key]
    public int NotificationTypeId { get; set; }

    [StringLength(100)]
    public string TypeName { get; set; } = null!;

    [InverseProperty("NotificationType")]
    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
