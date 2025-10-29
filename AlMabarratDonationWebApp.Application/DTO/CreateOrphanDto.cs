using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlMabarratDonationWebApp.Core.Entities;

namespace AlMabarratDonationWebApp.Application.DTO
{
    public class CreateOrphanDto
    {
        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; } = null!;

        [Required]
        public int Age { get; set; }

        public string? LostParents { get; set; }
        public string? Status { get; set; }

        [Required]
        public DateOnly DateJoined { get; set; }

        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? Nationality { get; set; }
        public string? HealthCondition { get; set; }
    }

}
