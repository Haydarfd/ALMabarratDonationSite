using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlMabarratDonationWebApp.Application.DTO
{
    public class CreateSponsorshipDto
    {
        public int? SponsorshipTypeId { get; set; }
        public int? DonorId { get; set; }
        public int? OrphanId { get; set; }
        public int? OrphanAge { get; set; }
        public string? OrphanGender { get; set; }
        public string? PaymentType { get; set; }
        public string? SponsorshipType { get; set; }
        public decimal? Amount { get; set; }

    }


}
