using System;

namespace AlMabarratDonationWebApp.Application.DTO
{
    public class OrphanDto
    {
        public int OrphanID { get; set; }
        public string FullName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public int Age { get; set; }
        public string? LostParents { get; set; }
        public string? Status { get; set; }
        public DateOnly DateJoined { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? Nationality { get; set; }
        public string? HealthCondition { get; set; }
        public string SponsorshipType { get; set; }
    }

}
