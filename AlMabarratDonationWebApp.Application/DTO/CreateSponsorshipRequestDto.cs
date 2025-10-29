using System.ComponentModel.DataAnnotations;

namespace AlMabarratDonationWebApp.Application.DTO
{
    public class CreateSponsorshipRequestDto
    {
        public int Id { get; set; }

        public string? AppUserId { get; set; }
        public int? DonorId { get; set; }


        [Required(ErrorMessage = "Age Group is required")]
        public string? AgeGroup { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Payment Type is required")]
        public string? PaymentType { get; set; }

        [Required(ErrorMessage = "Sponsorship Type is required")]
        public string? SponsorshipType { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than zero")]
        public decimal? Amount { get; set; }

        public DateTime RequestedOn { get; set; }
        public bool IsHandled { get; set; }
    }
}
