namespace AlMabarratDonationWebApp.Application.DTO
{
    public class UpdateSponsorshipRequestDto
    {
        public int Id { get; set; }
        public string? AgeGroup { get; set; }
        public string? Gender { get; set; }
        public string? SponsorshipType { get; set; }
        public decimal? Amount { get; set; }
        public bool IsHandled { get; set; }
    }
}
