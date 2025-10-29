using AlMabarratDonationWebApp.Core.Entities;
using System;
using System.Collections.Generic;

namespace AlMabarratDonationWebApp.Core.Entities;

public partial class SupportType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Orphan> Orphans { get; set; } = new List<Orphan>();

    public virtual ICollection<Sponsorship> Sponsorships { get; set; } = new List<Sponsorship>();
}
