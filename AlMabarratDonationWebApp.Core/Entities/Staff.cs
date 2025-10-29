using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AlMabarratDonationWebApp.Core.Entities;

public partial class Staff
{
    [Key]
    public int StaffID { get; set; }

    [StringLength(450)]
    public string UserID { get; set; } = null!;

    public DateOnly JoinDate { get; set; }

    public bool IsActive { get; set; }

    public bool RequiresPasswordChange { get; set; }

    [ForeignKey("UserID")]
    [InverseProperty("Staff")]
    public virtual AspNetUser User { get; set; } = null!;
}
