using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlMabarratDonationWebApp.Application.DTO
{
    public class EventDto
    {
        public int EventId { get; set; }
        public string? TitleEn { get; set; }
        public string? TitleAr { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
        public DateTime? EventDate { get; set; }
        public string? Location { get; set; }
        public string? Organizer { get; set; }
        public string? MediaUrls { get; set; }
    }
}
