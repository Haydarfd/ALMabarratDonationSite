using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlMabarratDonationWebApp.Application.DTO
{
    public class DonorDto
    {
        public int Id { get; set; }
        public string AppUserId { get; set; } = null!;

        public string? AppUserName { get; set; } // Allow null for AppUserName
        public string? Address { get; set; }    // Allow null for Address
        public string? City { get; set; }       // Allow null for City
        public string? PostalCode { get; set; } // Allow null for PostalCode
        public string? Country { get; set; }    // Allow null for Country
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
