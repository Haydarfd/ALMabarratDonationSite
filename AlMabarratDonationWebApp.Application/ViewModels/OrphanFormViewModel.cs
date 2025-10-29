using AlMabarratDonationWebApp.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlMabarratDonationWebApp.Application.ViewModels
{
    public class OrphanFormViewModel
    {
        public Orphan Orphan { get; set; }

        public List<SelectListItem> Nationalities { get; set; } = new();
    }

}
