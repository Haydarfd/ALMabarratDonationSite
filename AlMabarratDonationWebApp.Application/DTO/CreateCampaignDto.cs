using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlMabarratDonationWebApp.Application.DTO
{
    public class CreateCampaignDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? TargetAmount { get; set; }
        public string? Country { get; set; }
        public string? MediaUrls { get; set; }
    }

}
