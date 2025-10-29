using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AlMabarratDonationWebApp.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlMabarratDonationWebApp.Application.ViewModels
{
    public class CreateOrphanViewModel
    {
        public int OrphanID { get; set; }


        public string FullName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string? LostParents { get; set; }
        public string? Status { get; set; }
        public DateOnly DateJoined { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? Nationality { get; set; }
        public string? HealthCondition { get; set; }

        // Add this property to hold the list of nationalities
        public IEnumerable<SelectListItem> Nationalities { get; set; } = new List<SelectListItem>();
        public List<string>? NationalityOptions { get; set; }

    }

}
